using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.Lectures
{
    public class EditModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public EditModel(jhyf.Data.ApplicationDbContext context)
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

            var addlectures =  await _context.Lectures.FirstOrDefaultAsync(m => m.Id == id);
            if (addlectures == null)
            {
                return NotFound();
            }
            AddLectures = addlectures;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AddLectures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddLecturesExists(AddLectures.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AddLecturesExists(int id)
        {
            return _context.Lectures.Any(e => e.Id == id);
        }
    }
}
