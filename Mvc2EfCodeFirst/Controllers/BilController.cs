using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc2EfCodeFirst.Data;
using Mvc2EfCodeFirst.ViewModels;

namespace Mvc2EfCodeFirst.Controllers
{
    public class BilController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BilController(ILogger<BilController> logger, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public IActionResult Index()
        {
            var viewModel = new BilIndexViewModel();
            viewModel.Items = _dbContext.Bil.Select(e => new BilIndexViewModel.Item
            {
                Id = e.Id,
                Manufacturer = e.Manufacturer
            }).ToList();
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult New()
        {
            var viewModel = new BilNewViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(BilNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bil = new Bil
                {
                    Model = viewModel.Model,
                    Manufacturer = viewModel.Manufacturer,
                    Year = viewModel.Year,
                    Price = viewModel.Price,
                    Color = viewModel.Color
                };
                _dbContext.Bil.Add(bil);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }









        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bil = _dbContext.Bil.First(r => r.Id == id);
            var viewModel = new BilEditViewModel
            {
                Model = bil.Model,
                Manufacturer = bil.Manufacturer,
                Year = bil.Year,
                Price = bil.Price,
                Color = bil.Color,
                Id = bil.Id
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BilEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bil = _dbContext.Bil.First(r => r.Id == viewModel.Id);
                bil.Model = viewModel.Model;
                bil.Color = viewModel.Color;
                bil.Manufacturer = viewModel.Manufacturer;
                bil.Year = viewModel.Year;
                bil.Price = viewModel.Price;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


    }
}