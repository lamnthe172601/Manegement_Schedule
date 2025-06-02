namespace Management_Schedule_BE.Services.SystemSerivce.StoreService
{
    public interface IStorageService
    {
        Task<string?> UploadFileAsync(IFormFile file);
    }
}
