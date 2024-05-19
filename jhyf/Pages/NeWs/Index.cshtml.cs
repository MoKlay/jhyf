using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.NeWs
{
    public class IndexModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        IWebHostEnvironment _appEnvironment;

        public IndexModel(jhyf.Data.ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IList<AddNews> AddNews { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AddNews = await _context.News.ToListAsync();
        }
    }
}
