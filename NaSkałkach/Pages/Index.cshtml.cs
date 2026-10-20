using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NaSkałkach.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<string> ImageUrls { get; set; } = new List<string>();

        public void OnGet()
        {
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "gallery");

            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.*")
                    .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                   file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                   file.EndsWith(".png", StringComparison.OrdinalIgnoreCase));
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    ImageUrls.Add($"/images/gallery/{fileName}");
                }
            }
        }
    }
}
