using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteStreammingSilvio0405.BancoDeDados;
using SiteStreammingSilvio0405.Models;
using System.Diagnostics;

namespace SiteStreammingSilvio0405.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _context;

        public HomeController(ILogger<HomeController> logger,Contexto context)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Streammings.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}