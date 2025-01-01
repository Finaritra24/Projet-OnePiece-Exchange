using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace OnePiece.Pages_Proposals
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proposal Proposal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal =  await _context.Proposals.FirstOrDefaultAsync(m => m.ProposalID == id);
            if (proposal == null)
            {
                return NotFound();
            }
            Proposal = proposal;
           ViewData["ProposedTreasureID"] = new SelectList(_context.Treasures, "TreasureID", "TreasureID");
           ViewData["ProposingPirateID"] = new SelectList(_context.Pirates, "PirateID", "PirateID");
           ViewData["RequestingPirateID"] = new SelectList(_context.Pirates, "PirateID", "PirateID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Proposal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProposalExists(Proposal.ProposalID))
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

        private bool ProposalExists(int id)
        {
            return _context.Proposals.Any(e => e.ProposalID == id);
        }
    }
}
