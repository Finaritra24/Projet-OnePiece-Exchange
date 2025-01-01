using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnePiece.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnePiece.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginInput Input { get; set; }

        public class LoginInput
        {
            public string Denomination { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            HttpContext.Session.Remove("PirateID");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var pirate = await _context.Pirates
                .FirstOrDefaultAsync(m => m.Denomination == Input.Denomination && m.Password == Input.Password);

            if (pirate == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            HttpContext.Session.SetString("PirateID", pirate.PirateID.ToString());
            return RedirectToPage("/Index");
        }
    }
}
