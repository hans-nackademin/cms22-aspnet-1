namespace _02_ProfileAndImageUpload.Services
{
    public class LocalFileUpload
    {
        private readonly IWebHostEnvironment _env;

        public LocalFileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var profilePath = $"{_env.WebRootPath}/images/profiles";
            var imageName = $"profile_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = $"{profilePath}/{imageName}";

            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);

            return imageName;
        }
    }
}
