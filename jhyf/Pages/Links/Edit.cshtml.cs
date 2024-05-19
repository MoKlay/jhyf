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
using Microsoft.AspNetCore.Authorization;

namespace jhyf.Pages.Links
{
    //[Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public EditModel(jhyf.Data.ApplicationDbContext context)
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

            var link =  await _context.Links.FirstOrDefaultAsync(m => m.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            Link = link;
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

            _context.Attach(Link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(Link.Id))
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

        private bool LinkExists(int id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}
