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
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int TreasureID { get; set; }

        [BindProperty]
        public int PirateID { get; set; }

        [BindProperty]
        public int RequestingPirateID { get; set; }

        [BindProperty]
        public Proposal Proposal { get; set; } = default!;

        public IActionResult OnGet(int treasureID, int pirateID)
        {
            TreasureID = treasureID;
            PirateID = pirateID;
            RequestingPirateID = HttpContext.Session.GetInt32("PirateID") ?? 0;
            System.Console.WriteLine("PIRATYY");
            System.Console.WriteLine(RequestingPirateID+","+TreasureID+","+PirateID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RequestingPirateID = HttpContext.Session.GetInt32("PirateID") ?? 0;
            var pirate = await _context.Pirates.FirstOrDefaultAsync(m => m.PirateID == RequestingPirateID);
            if (pirate?.Budget < Proposal.ProposedOfferAmount)
            {
                ModelState.AddModelError(string.Empty, "Budget Insuffisant");
                return Page();
            }

            Proposal.RequestingPirateID = RequestingPirateID;
            Proposal.ProposingPirateID = PirateID;
            Proposal.ProposedTreasureID = TreasureID;
            Proposal.DateProposal = DateTime.Now;
            Proposal.DateReplyProposal = DateTime.Now;
            Proposal.State = 1;
            Proposal.Category = 0;
            Proposal.CounterOfferAmount = 0;
            _context.Proposals.Add(Proposal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
