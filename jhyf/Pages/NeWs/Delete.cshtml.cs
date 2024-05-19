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
    public class DeleteModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public DeleteModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddNews AddNews { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addnews = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (addnews == null)
            {
                return NotFound();
            }
            else
            {
                AddNews = addnews;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addnews = await _context.News.FindAsync(id);
            if (addnews != null)
            {
                AddNews = addnews;
                _context.News.Remove(AddNews);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
