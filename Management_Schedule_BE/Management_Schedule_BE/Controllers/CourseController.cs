using Management_Schedule_BE.DTOs.Request;
using Management_Schedule_BE.DTOs.Respond;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<CourseListResponseDTO>> GetAll([FromQuery] CourseFilterRequestDTO filter)
        {
            try
            {
                var courses = await _courseService.GetAllAsync(filter);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailResponseDTO>> GetById(int id)
        {
            try
            {
                var course = await _courseService.GetByIdAsync(id);
                if (course == null)
                {
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CourseResponseDTO>> Create(CreateCourseRequestDTO courseDto)
        {
            try
            {
                var createdCourse = await _courseService.CreateAsync(courseDto);
                return Ok(new { message = "Tạo thành công khóa học mới" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseResponseDTO>> Update(int id, UpdateCourseRequestDTO courseDto)
        {
            try
            {
                var updatedCourse = await _courseService.UpdateAsync(id, courseDto);
                if (updatedCourse == null)
                {
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                }
                return Ok(updatedCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _courseService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                }
                return Ok(new { message = "Xóa khóa học thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
} 