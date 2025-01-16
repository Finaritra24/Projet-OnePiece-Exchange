using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnePiece.ADO;
using OnePiece.Models;
using System.Collections.Generic;

namespace OnePiece.Areas.FrontOffice.Controllers
{
    [Area("FrontOffice")]
    public class ProposalsAdoController : Controller
    {
        private readonly ProposalsAdo _proposalsAdo;

        public ProposalsAdoController(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            _proposalsAdo = new ProposalsAdo(connectionString);
        }

        public IActionResult Index(string searchTerm)
        {
            List<Proposal> proposals = _proposalsAdo.GetAll(searchTerm);

            ViewData["SearchTerm"] = searchTerm;

            return View(proposals);
        }
    }
}
