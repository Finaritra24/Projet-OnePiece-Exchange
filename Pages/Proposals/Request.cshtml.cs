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
            .FromSqlRaw("SELECT * FROM Proposal where RequestingPirateID = " + PirateID +" and state = 0")
            .Include(p => p.ProposedTreasure)
            .Include(p => p.ProposingPirate)
            .Include(p => p.RequestingPirate)
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        }
    }
}
