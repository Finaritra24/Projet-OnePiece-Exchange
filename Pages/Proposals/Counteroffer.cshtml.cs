using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace MyApp.Namespace
{
    public class CounterofferModel : PageModel
    {
        [BindProperty]
        public int ProposalID { get; set; }


        [BindProperty]
        public decimal Countofferprice { get; set; } = default!;

        private readonly AppDbContext _context;
        public CounterofferModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int proposalID)
        {
            ProposalID = proposalID;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var proposal = await _context.Proposals
                .FirstOrDefaultAsync(p => p.ProposalID == ProposalID);
            proposal.CounterOfferAmount = Countofferprice;
            proposal.DateReplyProposal = DateTime.Now;
            proposal.Category = 1;
            proposal.State = 1;
            Proposal Proposal = proposal;
            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
