using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.DTOs.Respond
{
    public class SessionCodeResponseDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime ExpiryTime { get; set; }
        public SessionCodeStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class SessionCodeDetailResponseDTO : SessionCodeResponseDTO
    {
        public ScheduleResponseDTO Schedule { get; set; }
    }

    public class SessionCodeListResponseDTO
    {
        public List<SessionCodeResponseDTO> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 