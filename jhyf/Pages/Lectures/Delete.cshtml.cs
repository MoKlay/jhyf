using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.Lectures
{
    public class DeleteModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public DeleteModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddLectures AddLectures { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addlectures = await _context.Lectures.FirstOrDefaultAsync(m => m.Id == id);

            if (addlectures == null)
            {
                return NotFound();
            }
            else
            {
                AddLectures = addlectures;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addlectures = await _context.Lectures.FindAsync(id);
            if (addlectures != null)
            {
                AddLectures = addlectures;
                _context.Lectures.Remove(AddLectures);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
