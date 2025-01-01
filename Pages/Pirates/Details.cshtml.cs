using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace OnePiece.Pages_Pirates
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Pirate Pirate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pirate = await _context.Pirates.FirstOrDefaultAsync(m => m.PirateID == id);

            if (pirate is not null)
            {
                Pirate = pirate;

                return Page();
            }

            return NotFound();
        }
    }
}
