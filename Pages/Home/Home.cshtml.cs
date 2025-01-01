using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace MyApp.Namespace;

public class HomeModel : PageModel
{
    private readonly AppDbContext _context;

    public HomeModel(AppDbContext context)
    {
        _context = context;
    }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public int TotalPages { get; set; } 

    public int PageNumberTopRecent { get; set; } = 1;
    public int PageSizeTopRecent { get; set; } = 5;
    public int TotalPagesTopRecent { get; set; }

    public IList<Treasure> Treasure { get; set; } = default!;
    public IList<Treasure> TopRecentTreasures { get; set; } = default!;

    public async Task OnGetAsync(int pageNumber = 1, int pageNumberTopRecent = 1)
    {
        PageSize = 5;
        PageNumber = pageNumber;
        var totalItems = await _context.Treasures.CountAsync();
        TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

        Treasure = await _context.Treasures
            .Include(t => t.Category)
            .Include(t => t.Pirate)
            .Skip((pageNumber - 1) * PageSize)  
            .Take(PageSize) 
            .ToListAsync();

        // Calculer les pages pour TopRecentTreasures
        PageSizeTopRecent = 5;
        PageNumberTopRecent = pageNumberTopRecent;
        var totalItemsTopRecent = await _context.Treasures.CountAsync();
        TotalPagesTopRecent = (int)Math.Ceiling(totalItemsTopRecent / (double)PageSizeTopRecent); 

        TopRecentTreasures = await _context.Treasures
            .FromSqlRaw("SELECT TOP 5 * FROM Treasure ORDER BY dateCreation DESC")
            .Skip((PageNumberTopRecent - 1) * PageSizeTopRecent)
            .Take(PageSizeTopRecent)
            .ToListAsync();
    }
}
