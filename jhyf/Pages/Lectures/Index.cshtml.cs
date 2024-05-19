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
    public class IndexModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public IndexModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AddLectures> AddLectures { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AddLectures = await _context.Lectures.ToListAsync();
        }
    }
}
