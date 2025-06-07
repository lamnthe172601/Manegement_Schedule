using Management_Schedule_BE.Data;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Services
{
    public class ScheduleStatusBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _checkInterval = TimeSpan.FromSeconds(10); // Kiểm tra mỗi giờ

        public ScheduleStatusBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await UpdateScheduleStatuses();
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi
                }

                await Task.Delay(_checkInterval, stoppingToken);
            }
        }

        private async Task UpdateScheduleStatuses()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var now = DateTime.Now;

            var ongoingSchedules = context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.Status == 0 && s.Date.Date == now.Date)
                .AsEnumerable()
                .Where(s =>
                {
                    var start = TimeSpan.Parse(s.StudySession.StartTime);
                    var end = TimeSpan.Parse(s.StudySession.EndTime);
                    return start <= now.TimeOfDay && end > now.TimeOfDay;
                })
                .ToList();

            foreach (var schedule in ongoingSchedules)
            {
                schedule.Status = 1;
                schedule.ModifiedAt = now;
            }

            var completedSchedules = context.Schedules
                .Include(s => s.StudySession)
                .Where(s => s.Status == 1)
                .AsEnumerable()
                .Where(s =>
                    s.Date.Date < now.Date ||
                    (s.Date.Date == now.Date && TimeSpan.Parse(s.StudySession.EndTime) <= now.TimeOfDay)
                )
                .ToList();

            foreach (var schedule in completedSchedules)
            {
                schedule.Status = 2;
                schedule.ModifiedAt = now;
            }

            await context.SaveChangesAsync();
        }
    }
} 