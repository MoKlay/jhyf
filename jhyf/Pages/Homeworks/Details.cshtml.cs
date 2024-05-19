using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.Homeworks
{
    public class DetailsModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public DetailsModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AddHomework AddHomework { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addhomework = await _context.Homeworks.FirstOrDefaultAsync(m => m.Id == id);
            if (addhomework == null)
            {
                return NotFound();
            }
            else
            {
                AddHomework = addhomework;
            }
            return Page();
        }
    }
}
