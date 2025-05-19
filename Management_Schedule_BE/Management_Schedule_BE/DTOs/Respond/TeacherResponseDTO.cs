using System;
using System.Collections.Generic;
using Management_Schedule_BE.DTOs.Respond;

namespace Management_Schedule_BE.DTOs.Respond
{
    public class TeacherResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class TeacherDetailResponseDTO : TeacherResponseDTO
    {
        public List<ClassResponseDTO> Classes { get; set; }
        public List<ScheduleResponseDTO> Schedules { get; set; }
        public List<TeacherSalaryHistoryResponseDTO> SalaryHistory { get; set; }
    }

    public class TeacherListResponseDTO
    {
        public List<TeacherResponseDTO> Teachers { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 