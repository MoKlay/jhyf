using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jhyf.Data;
using jhyf.Data.Identity;
using Microsoft.AspNetCore.Authorization;

namespace jhyf.Pages.Links
{
    //[Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public DeleteModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Link Link { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links.FirstOrDefaultAsync(m => m.Id == id);

            if (link == null)
            {
                return NotFound();
            }
            else
            {
                Link = link;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                Link = link;
                _context.Links.Remove(Link);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
