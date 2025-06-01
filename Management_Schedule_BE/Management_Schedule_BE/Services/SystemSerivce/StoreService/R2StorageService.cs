
using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.Extensions.Options;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services.SystemSerivce.StoreService
{
    public class R2StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly R2Config _r2Config;

        public R2StorageService(IAmazonS3 s3Client, IOptions<R2Config> r2Config)
        {
            _s3Client = s3Client;
            _r2Config = r2Config.Value;
        }

        public async Task<string?> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;

            // Tạo một tên file duy nhất để tránh bị trùng lặp
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";

            var request = new PutObjectRequest
            {
                BucketName = _r2Config.BucketName,
                Key = fileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };
            // Cho phép truy cập công khai file này
            request.Metadata.Add("x-amz-acl", "public-read");


            var response = await _s3Client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                // Trả về URL công khai của file
                return $"{_r2Config.PublicUrlBase}/{fileName}";
            }

            return null;
        }
    }
}
