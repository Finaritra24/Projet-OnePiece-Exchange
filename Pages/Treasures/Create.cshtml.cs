using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnePiece.Models;

namespace OnePiece.Pages_Treasures
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryID");
        ViewData["PirateID"] = new SelectList(_context.Pirates, "PirateID", "PirateID");
            return Page();
        }

        [BindProperty]
        public Treasure Treasure { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Treasures.Add(Treasure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostImportAsync(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Veuillez s�lectionner un fichier CSV.");
                return Page();
            }

            using (var stream = new StreamReader(csvFile.OpenReadStream()))
            {
                string line;
                var treasures = new List<Treasure>();
                bool isFirstLine = true;  // D�clar� hors de la boucle

                // Lire chaque ligne du fichier CSV
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    if (isFirstLine)
                    {
                        // On saute juste UNE fois, pour la 1re ligne (ent�tes)
                        isFirstLine = false;
                        continue;
                    }

                    var values = line.Split(',');

                    if (values.Length < 5) // Ajustez selon les colonnes dans votre CSV
                    {
                        // Ignorer les lignes incompl�tes
                        continue;
                    }

                    // Exemple de mappage des colonnes CSV � votre mod�le Treasure
                    var treasure = new Treasure
                    {
                        Denomination = values[0],
                        Price = decimal.TryParse(values[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var price)
                                    ? price : 0,
                        PirateID = int.TryParse(values[2], out var pirateId)
                                    ? pirateId : 0,
                        CategoryID = int.TryParse(values[3], out var categoryId)
                                    ? categoryId : 0,
                        State = int.TryParse(values[4], out var Status)
                                    ? Status : 0,
                        Description = values[5],
                    };

                    treasures.Add(treasure);
                }

                // Ajouter toutes les entr�es dans la base de donn�es
                _context.Treasures.AddRange(treasures);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
