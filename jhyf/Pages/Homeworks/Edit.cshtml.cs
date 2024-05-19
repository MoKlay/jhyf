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

namespace jhyf.Pages.Homeworks
{
    public class EditModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public EditModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddHomework AddHomework { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addhomework =  await _context.Homeworks.FirstOrDefaultAsync(m => m.Id == id);
            if (addhomework == null)
            {
                return NotFound();
            }
            AddHomework = addhomework;
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

            _context.Attach(AddHomework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddHomeworkExists(AddHomework.Id))
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

        private bool AddHomeworkExists(int id)
        {
            return _context.Homeworks.Any(e => e.Id == id);
        }
    }
}
