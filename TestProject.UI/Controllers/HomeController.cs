using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestProject.Application.Services;
using TestProject.Common.Models;
using TestProject.UI.Models;

namespace TestProject.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
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

        #region Bu method larni ui qismiga ulgura olmadim
        public IActionResult Details(Guid id)
        {
            var reportDetails = _productService.GetById(id);
            return View(reportDetails);
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Administrator")]
        [HttpPost]
        public IActionResult Create(Product newReport)
        {
            if (!ModelState.IsValid)
                return View(newReport);

            var newReportId = _productService.AddNew(newReport);
            return RedirectToAction("Details", new { id = newReportId });
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var reportDetails = _productService.GetById(id);
            return View(reportDetails);
        }

        [Authorize(Policy = "Administrator")]
        [HttpPost]
        public IActionResult Edit(Product report)
        {
            if (!ModelState.IsValid)
                return View(report);

            var isEdit = _productService.Update(report);

            if (isEdit)
                return RedirectToAction("Details", new { id = report.Id });

            return View(report);
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Delete(Guid id)
        {
            var isDelete = _productService.Delete(id);
            if (isDelete)
                return RedirectToAction("Index");
            return RedirectToAction("Details", new { id = id });
        }

        #endregion
    }
}