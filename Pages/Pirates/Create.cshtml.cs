using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnePiece.Models;

namespace OnePiece.Pages_Pirates
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID");
            return Page();
        }

        [BindProperty]
        public Pirate Pirate { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Pirates.Add(Pirate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
