using Microsoft.AspNetCore.Mvc;
using SampleMVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using AdventureWorksNS.Data;    

namespace SampleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdventureWorksDB db;

        public HomeController(ILogger<HomeController> logger, AdventureWorksDB injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            _logger.LogError("This is a serious error");
            _logger.LogWarning("This is a warning");
            _logger.LogWarning("This is a second warning");
            _logger.LogInformation("I am in the index method of HOME Controller");
            HomeIndexViewModel model = new(
                VisitorCount: (new Random()).Next(1, 1001),
                Categories: db.ProductCategories.ToList(),
                Products: db.Products.ToList()
                );
            return View(model);
        }

        [Route("private")]
        [Authorize(Roles = "Administrators")]
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