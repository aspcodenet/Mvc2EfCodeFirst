using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc2EfCodeFirst.Data;
using Mvc2EfCodeFirst.ViewModels;

namespace Mvc2EfCodeFirst.Controllers
{
    public class BilController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public BilController(ILogger<BilController> logger, ApplicationDbContext dbContext,
            IWebHostEnvironment environment
            )
        {
            _dbContext = dbContext;
            _environment = environment;
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


        [HttpGet]
        public IActionResult RegNoDuplicateCheck(string RegNo)
        {
            if (_dbContext.Bil.Any(r => r.RegNo == RegNo))
            {
                return Json("Bilen är redan registrerad");
            }

            return Json(true);

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
                    Color = viewModel.Color,
                    RegNo = viewModel.RegNo
                };
                _dbContext.Bil.Add(bil);
                _dbContext.SaveChanges();


                string filename = bil.Id + ".jpg";
                string totalPath = Path.Combine(_environment.WebRootPath,
                    "images", filename);
                using (var fileStream = new FileStream(totalPath, FileMode.Create))
                {
                    viewModel.NyBild.CopyTo(fileStream);
                }




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
                Id = bil.Id,
                RegNo = bil.RegNo
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
                bil.RegNo = viewModel.RegNo;
                _dbContext.SaveChanges();


                string filename = viewModel.Id + ".jpg";
                string totalPath = Path.Combine(_environment.WebRootPath, 
                    "images", filename);
                using (var fileStream = new FileStream(totalPath, FileMode.Create))
                {
                    viewModel.NyBild.CopyTo(fileStream);
                }


                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


    }
}