using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Management_Schedule_BE.DTOs.Request;
using Management_Schedule_BE.DTOs.Respond;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.Repositories;
using Management_Schedule_BE.Services.Base;
using Management_Schedule_BE.Services.Exceptions;
using Management_Schedule_BE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Services.Implement
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(CourseRepository repository, IMapper mapper) : base(repository)
        {
            _courseRepository = repository;
            _mapper = mapper;
        }

        public async Task<CourseListResponseDTO> GetAllAsync(CourseFilterRequestDTO filter)
        {
            try
            {
                var query = _courseRepository.GetQueryable();

                // Nếu không có filter, trả về toàn bộ danh sách
                if (filter == null || (
                    string.IsNullOrEmpty(filter.SearchTerm) &&
                    string.IsNullOrEmpty(filter.Level) &&
                    string.IsNullOrEmpty(filter.Status) &&
                    !filter.MinPrice.HasValue &&
                    !filter.MaxPrice.HasValue))
                {
                    var allDtos = await query
                        .ProjectTo<CourseResponseDTO>(_mapper.ConfigurationProvider)
                        .ToListAsync();
                    return new CourseListResponseDTO
                    {
                        Courses = allDtos,
                        TotalCount = allDtos.Count,
                        PageNumber = 1,
                        PageSize = allDtos.Count
                    };
                }

                // Áp dụng bộ lọc
                if (!string.IsNullOrEmpty(filter.SearchTerm))
                    query = query.Where(c => c.CourseName.Contains(filter.SearchTerm) || c.Description.Contains(filter.SearchTerm));
                if (!string.IsNullOrEmpty(filter.Level))
                    query = query.Where(c => c.IsPro.ToString() == filter.Level);
                if (!string.IsNullOrEmpty(filter.Status))
                    query = query.Where(c => c.IsSelling.ToString() == filter.Status);
                if (filter.MinPrice.HasValue)
                    query = query.Where(c => c.Price >= filter.MinPrice.Value);
                if (filter.MaxPrice.HasValue)
                    query = query.Where(c => c.Price <= filter.MaxPrice.Value);

                var totalCount = await query.CountAsync();
                var courseDtos = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ProjectTo<CourseResponseDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return new CourseListResponseDTO
                {
                    Courses = courseDtos,
                    TotalCount = totalCount,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new ServiceException("Lỗi khi lấy danh sách khóa học", ex);
            }
        }

        public async Task<CourseDetailResponseDTO> GetByIdAsync(int id)
        {
            try
            {
                var query = _courseRepository.GetQueryable();
                var course = await query
                    .Include(c => c.Classes)
                    .Include(c => c.Lessons)
                    .FirstOrDefaultAsync(c => c.CourseID == id);

                if (course == null)
                    return null;

                return _mapper.Map<CourseDetailResponseDTO>(course);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi khi lấy thông tin khóa học {id}", ex);
            }
        }

        public async Task<CourseResponseDTO> CreateAsync(CreateCourseRequestDTO courseDto)
        {
            try
            {
                // Kiểm tra trùng tên
                if (await _courseRepository.GetQueryable().AnyAsync(c => c.CourseName == courseDto.Name))
                    throw new ServiceException($"Tên khóa học '{courseDto.Name}' đã tồn tại.");

                var course = _mapper.Map<Course>(courseDto);
                course.CourseName = courseDto.Name;
                course.Description = courseDto.Description;
                course.Price = courseDto.Price;
                course.IsPro = courseDto.Level == "Pro";
                course.IsSelling = courseDto.Status == "Active";
                course.IsComingSoon = false;
                course.IsCompletable = true;
                course.DiscountPercent = 0;

                await _courseRepository.AddAsync(course);
                await _courseRepository.SaveChangesAsync();
                return _mapper.Map<CourseResponseDTO>(course);
            }
            catch (ServiceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Lỗi khi tạo khóa học mới", ex);
            }
        }

        public async Task<CourseResponseDTO> UpdateAsync(int id, UpdateCourseRequestDTO courseDto)
        {
            try
            {
                var course = await _courseRepository.GetByIdAsync(id);
                if (course == null)
                    return null;

                // Map các trường update từ DTO sang entity
                if (!string.IsNullOrEmpty(courseDto.Name))
                    course.CourseName = courseDto.Name;
                if (!string.IsNullOrEmpty(courseDto.Description))
                    course.Description = courseDto.Description;
                if (courseDto.Price.HasValue)
                    course.Price = courseDto.Price.Value;
                if (!string.IsNullOrEmpty(courseDto.Level))
                    course.IsPro = courseDto.Level == "Pro";
                if (!string.IsNullOrEmpty(courseDto.Status))
                    course.IsSelling = courseDto.Status == "Active";

                _courseRepository.Update(course);
                await _courseRepository.SaveChangesAsync();
                return _mapper.Map<CourseResponseDTO>(course);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi khi cập nhật khóa học {id}", ex);
            }
        }
    }

    public static class CourseRepositoryExtensions
    {
        public static IQueryable<Course> GetQueryable(this CourseRepository repo)
        {
            var contextField = typeof(CourseRepository).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var context = (DbContext)contextField.GetValue(repo);
            return context.Set<Course>().AsQueryable();
        }
    }
} 