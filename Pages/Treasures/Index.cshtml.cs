using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace OnePiece.Pages_Treasures
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Treasure> Treasure { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Treasure = await _context.Treasures
                .Include(t => t.Pirate).ToListAsync();
        }
    }
}
