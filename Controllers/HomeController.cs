using System.Diagnostics;
using Lethon.Entities;
using Lethon.Models;
using Lethon.NHibernate;
using Microsoft.AspNetCore.Mvc;

namespace Lethon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IRepository<Product> repository, IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _repository.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(product);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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
