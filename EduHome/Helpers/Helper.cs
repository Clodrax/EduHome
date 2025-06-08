using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EduHome.Helpers
{
    public static class Helper
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool IsOlder1mb(this IFormFile file)
        {
            return file.Length / 1024 > 1024;
        }
        public static async Task<string> SaveImageAsync(this IFormFile file, string folder)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(folder, filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }


            return filename;
        }
        public const string Admin = "Admin";
        public const string Member = "Member";
    }
}
