using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace OnePiece.Pages_Proposals
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Proposal> Proposal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Proposal = await _context.Proposals
                .Include(p => p.ProposedTreasure)
                .Include(p => p.ProposingPirate)
                .Include(p => p.RequestingPirate).ToListAsync();

            Proposal = Proposal.OrderByDescending(p => p.DateReplyProposal).ToList();
        }
    }
}
