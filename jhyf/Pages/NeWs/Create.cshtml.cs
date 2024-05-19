using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jhyf.Data;
using jhyf.Data.Identity;
using jhyf.FileUploadServiice;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace jhyf.Pages.NeWs
{
    public class CreateModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        IWebHostEnvironment _appEnvironment;

        private readonly IFileUploadService fileUploadService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public string FilePath;

        public CreateModel(jhyf.Data.ApplicationDbContext context, IWebHostEnvironment appEnvironment, IFileUploadService _fileUploadService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            fileUploadService = _fileUploadService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddNews AddNews { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (file != null)
            {
                FilePath = await fileUploadService.UploadFileAsync(file);
            }

            //FilePath = FilePath.Substring(71);
            //C:\Users\cazaz\Downloads\ForMathTeach\ForMathTeach\jhyf\wwwroot\Images\сад с сакурой.jpg
            FilePath = FilePath.Substring(FilePath.IndexOf("Images"));

            FilePath = FilePath.Substring(7);

            AddNews = new AddNews
            {
                Title = AddNews.Title,
                NameFile = FilePath,
                ImageNews = AddNews.ImageNews,
                LinkImage = AddNews.LinkImage,
                Description = AddNews.Description,
                NameDoc = AddNews.NameDoc,
                LinkFile = AddNews.LinkFile
            };

            _context.News.Add(AddNews);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
