
namespace jhyf.FileUploadServiice
{
    public class LocalFileUploadService : IFileUploadService
    {
        private readonly IHostEnvironment environment;

        public LocalFileUploadService(IHostEnvironment _environment)
        {
            environment = _environment;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(environment.ContentRootPath, @"wwwroot\Images", file.FileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(fileStream);

            return filePath;
        }
    }
}
