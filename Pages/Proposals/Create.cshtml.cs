using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnePiece.Models;

namespace OnePiece.Pages_Proposals
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
        ViewData["ProposedTreasureID"] = new SelectList(_context.Treasures, "TreasureID", "TreasureID");
        ViewData["ProposingPirateID"] = new SelectList(_context.Pirates, "PirateID", "PirateID");
        ViewData["RequestingPirateID"] = new SelectList(_context.Pirates, "PirateID", "PirateID");
            return Page();
        }

        [BindProperty]
        public Proposal Proposal { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Proposals.Add(Proposal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}