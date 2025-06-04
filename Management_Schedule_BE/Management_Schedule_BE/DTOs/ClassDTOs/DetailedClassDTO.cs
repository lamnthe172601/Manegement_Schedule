using System;

namespace Management_Schedule_BE.DTOs
{
    public record DetailedClassDTO(
        int ClassID,
        string ClassName,
        int CourseID,
        int MaxStudents,
          string CourseName,
          int totalSlots,
        DateTime StartDate,
        DateTime? EndDate,
        byte Status,
        DateTime CreatedAt,
        DateTime ModifiedAt
      
    );
} 