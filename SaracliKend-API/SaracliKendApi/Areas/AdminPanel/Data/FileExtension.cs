using SaracliKend.Infrastructure.Resources;

namespace SaracliKendApi.Areas.AdminPanel.Data
{
    public static class FileExtension
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsVideo(this IFormFile file)
        {
            return file.ContentType.Contains("video");
        }

        public static bool IsAllowedSize(this IFormFile file, int mb)
        {
            return file.Length < mb * 1024 * 1000;
        }
        public static async Task<string> GenerateFile(this IFormFile file, string folderPath)
        {
            IsDirectoryExist(folderPath);   
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            var path = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(path, FileMode.CreateNew))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public static void DeleteFile(string filePath, string folderPath)
        {
            var path = Path.Combine(folderPath, filePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private static void IsDirectoryExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
