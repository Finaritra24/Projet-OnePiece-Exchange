using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace MyApp.Namespace
{
    public class RequestModel : PageModel
    {
        [BindProperty]
        public int PageNumber { get; set; } = 1;

        [BindProperty]
        public int PageSize { get; set; } = 5;

        [BindProperty]
        public int TotalPages { get; set; }

        [BindProperty]
        public IList<Proposal> Proposal { get; set; } = new List<Proposal>();


        [BindProperty]
        public int PirateID { get; set; } = 1;

        private readonly AppDbContext _context;
        public RequestModel(AppDbContext context) => _context = context;

        private async Task PopulateProposals(int pageNumber = 1)
        {
            // Récupérer l'ID du pirate via la session (ou autre)
            PirateID = HttpContext.Session.GetInt32("PirateID") ?? 0;
            if (PirateID == 0)
            {
                Proposal = new List<Proposal>();
                return;
            }

            PageSize = 5;              // Nombre d'éléments par page
            PageNumber = pageNumber;   // Page courante

            // Comptage du total d'items
            int totalItems = await _context.Proposals
            .FromSqlRaw($@"SELECT * FROM Proposal 
                   WHERE (state = 1 AND ProposingPirateID = {PirateID} AND category = 0) 
                      OR (state = 1 AND RequestingPirateID = {PirateID} AND category = 1) 
                      OR (state = 2 AND RequestingPirateID = {PirateID})")
            .Include(p => p.ProposedTreasure)
            .Include(p => p.RequestingPirate)
                .CountAsync();

            // Calcul du nombre total de pages
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            // Récupération paginée
            Proposal = await _context.Proposals
            .FromSqlRaw($@"SELECT * FROM Proposal 
                   WHERE (state = 1 AND ProposingPirateID = {PirateID} AND category = 0) 
                      OR (state = 1 AND RequestingPirateID = {PirateID} AND category = 1) 
                      OR (state = 2 AND RequestingPirateID = {PirateID})")
            .Include(p => p.ProposedTreasure)
            .Include(p => p.RequestingPirate) 
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        }


        public async Task OnGetAsync(int pageNumber = 1, int pageNumberTopRecent = 1)
        {
            await PopulateProposals(PageNumber);
        }

        public async Task<IActionResult> OnGetAcceptAsync(int proposalID)
        {
            var proposal = await _context.Proposals.FindAsync(proposalID);
            if (proposal == null) return NotFound();

            proposal.DateReplyProposal = DateTime.Now;
            proposal.State = 2;

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }



        public async Task<IActionResult> OnGetPaiementAsync(int proposalID)
        {
            // Récupération et vérifications
            var proposal = await _context.Proposals.FindAsync(proposalID);
            if (proposal == null) return NotFound();

            var treasure = await _context.Treasures.FindAsync(proposal.ProposedTreasureID);
            var pirate = await _context.Pirates.FindAsync(proposal.RequestingPirateID);
            var pirateProposing = await _context.Pirates.FindAsync(proposal.ProposingPirateID);
            if (treasure == null || pirate == null) return NotFound();

            if (pirate.Budget < proposal.ProposedOfferAmount || pirate.Budget < proposal.CounterOfferAmount)
            {
                ModelState.AddModelError(string.Empty, "Budget Insuffisant");

                // Re-run the same queries you'd do in OnGetAsync or factor them out
                // e.g.:
                await PopulateProposals(); // custom method that sets 'Proposal'

                return Page();
            }

            // Mise à jour des entités
            proposal.DateReplyProposal = DateTime.Now;
            proposal.State = 3;
            if(proposal.Category == 1)
            {
                treasure.Price = (decimal)proposal.ProposedOfferAmount;
                pirate.Budget -= (decimal)proposal.ProposedOfferAmount;
                pirateProposing.Budget += (decimal)proposal.ProposedOfferAmount;
            }
            else if(proposal.Category == 2){
                treasure.Price = (decimal)proposal.CounterOfferAmount;
                pirate.Budget -= (decimal)proposal.CounterOfferAmount;
                pirateProposing.Budget += (decimal)proposal.CounterOfferAmount;
            }

            _context.UpdateRange(proposal, treasure, pirate, pirateProposing);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetString("Budget", pirate.Budget.ToString());
            return RedirectToPage("/Home/home");
        }

        public async Task<IActionResult> OnGetRefuseAsync(int proposalID)
        {
            var proposal = await _context.Proposals.FindAsync(proposalID);
            if (proposal == null) return NotFound();

            proposal.DateReplyProposal = DateTime.Now;
            proposal.State = 0;

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
