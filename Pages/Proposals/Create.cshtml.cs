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

        public int TreasureID { get; set; }
        public int PirateID { get; set; }

        
        [BindProperty]
        public Proposal Proposal { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            Proposal.RequestingPirateID = 1;
            Proposal.ProposingPirateID = 1;
            Proposal.ProposedTreasureID = 1;
            Proposal.DateProposal = DateTime.Now;
            Proposal.DateReplyProposal = DateTime.Now;
            Proposal.State = 0;
            Proposal.Category = 0;
            Proposal.CounterOfferAmount = 0;
            _context.Proposals.Add(Proposal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
