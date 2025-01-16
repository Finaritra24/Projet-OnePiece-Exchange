using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

namespace OnePiece.Pages_Pirates
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pirate Pirate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            int id = HttpContext.Session.GetInt32("PirateID") ?? 0;

            var pirate =  await _context.Pirates.FirstOrDefaultAsync(m => m.PirateID == id);
            if (pirate == null)
            {
                return NotFound();
            }
            Pirate = pirate;
           ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            // R�cup�rer le pirate correspondant � l'ID
            var pirate = await _context.Pirates
                .FirstOrDefaultAsync(p => p.PirateID == Pirate.PirateID);

            if (pirate == null)
            {
                return NotFound(); // Si aucun pirate n'est trouv�
            }

            // Mettre � jour le budget en ajoutant la diff�rence
            pirate.Budget += Pirate.Budget;
            Console.WriteLine($"Budget envoy� depuis le formulaire : {pirate.Budget} et {Pirate.Budget}");
        
            // Mettre � jour les autres propri�t�s si n�cessaire
            _context.Pirates.Update(pirate);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetString("Budget", pirate.Budget.ToString());
            return RedirectToPage("/Home/home");
        }

        private bool PirateExists(int id)
        {
            return _context.Pirates.Any(e => e.PirateID == id);
        }
    }
}
