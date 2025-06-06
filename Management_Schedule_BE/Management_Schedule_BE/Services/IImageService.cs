using Microsoft.AspNetCore.Http;

namespace Management_Schedule_BE.Services
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile? imageFile, string defaultImagePath);
        Task<bool> DeleteImageAsync(string imageUrl);
        Task<string> UpdateImageAsync(IFormFile? newImageFile, string currentImageUrl, string defaultImagePath);
    }
} 