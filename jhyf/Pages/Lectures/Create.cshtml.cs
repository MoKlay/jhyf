using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.Lectures
{
    public class CreateModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public CreateModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddLectures AddLectures { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lectures.Add(AddLectures);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
