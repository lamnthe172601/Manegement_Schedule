using Management_Schedule_BE.Services.SystemSerivce.StoreService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Management_Schedule_BE.Services
{
    public class ImageService : IImageService
    {
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public ImageService(IStorageService storageService, IConfiguration configuration)
        {
            _storageService = storageService;
            _configuration = configuration;
        }

        public async Task<string> UploadImageAsync(IFormFile? imageFile, string defaultImagePath)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    return await _storageService.UploadFileAsync(imageFile);
                }
                return _configuration["R2:PublicUrlBase"] + defaultImagePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Upload image error: " + ex.ToString());
                throw;
            }
        }

        public async Task<bool> DeleteImageAsync(string imageUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    // Thêm logic xóa ảnh từ storage service nếu cần
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete image error: " + ex.ToString());
                return false;
            }
        }

        public async Task<string> UpdateImageAsync(IFormFile? newImageFile, string currentImageUrl, string defaultImagePath)
        {
            try
            {
                if (newImageFile != null && newImageFile.Length > 0)
                {
                    // Xóa ảnh cũ nếu có
                    if (!string.IsNullOrEmpty(currentImageUrl))
                    {
                        await DeleteImageAsync(currentImageUrl);
                    }
                    // Upload ảnh mới
                    return await UploadImageAsync(newImageFile, defaultImagePath);
                }
                return currentImageUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update image error: " + ex.ToString());
                throw;
            }
        }
    }
} 