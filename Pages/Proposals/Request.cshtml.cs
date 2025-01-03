using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace MyApp.Namespace
{
    public class RequestModel : PageModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
        public IList<Proposal> Proposal { get; set; } = default!;

        public int PirateID;

        private readonly AppDbContext _context;
        public RequestModel(AppDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(int pageNumber = 1, int pageNumberTopRecent = 1)
        {
            PirateID = HttpContext.Session.GetInt32("PirateID") ?? 0;
            PageSize = 5;
            PageNumber = pageNumber;
            var totalItems = await _context.Proposals.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            Proposal = await _context.Proposals
            .FromSqlRaw("SELECT * FROM Proposal where RequestingPirateID = " + PirateID +" and state = 1")
            .Include(p => p.ProposedTreasure)
            .Include(p => p.ProposingPirate)
            .Include(p => p.RequestingPirate)
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        }

        // Méthode pour accepter la proposition et modifier les modèles
        public async Task<IActionResult> OnGetAcceptAsync(int proposalID)
        {
            var proposal = await _context.Proposals
                .FirstOrDefaultAsync(p => p.ProposalID == proposalID);
            var treasure = await _context.Treasures
                .FirstOrDefaultAsync(t => t.TreasureID == proposal.ProposedTreasureID);

            if (proposal == null || treasure == null)
            {
                return NotFound();
            }
            proposal.DateReplyProposal = DateTime.Now;
            proposal.State = 2; 
            treasure.Price = (decimal)proposal.ProposedOfferAmount; 

            _context.Proposals.Update(proposal);
            _context.Treasures.Update(treasure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetRefuseAsync(int proposalID)
        {
            var proposal = await _context.Proposals
                .FirstOrDefaultAsync(p => p.ProposalID == proposalID);

            if (proposal == null)
            {
                return NotFound();
            }
            proposal.DateReplyProposal = DateTime.Now;
            proposal.State = 0;

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
