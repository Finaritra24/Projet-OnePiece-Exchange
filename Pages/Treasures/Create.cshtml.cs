using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnePiece.Models;

namespace OnePiece.Pages_Treasures
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
        ViewData["PirateID"] = new SelectList(_context.Pirates, "PirateID", "PirateID");
            return Page();
        }

        [BindProperty]
        public Treasure Treasure { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Treasures.Add(Treasure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
