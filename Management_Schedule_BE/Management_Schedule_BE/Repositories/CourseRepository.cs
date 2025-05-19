using Management_Schedule_BE.Models;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.Repositories.Generic;

namespace Management_Schedule_BE.Repositories
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
} 