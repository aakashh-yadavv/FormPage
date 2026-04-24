using FormPage.Models;
using FormPage.Service.Interface;
using FormPage.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FormPage.Controllers
{
    public class MainController : Controller
    {
        private readonly IFormService _formService;

        public MainController(IFormService formService)
        {
            _formService = formService;
        }

        // 🔹 GET: Page load
        [HttpGet]
        public IActionResult Submit()
        {
            var model = new MainForm
            {
                StudentForm = new Student(),
                EmployeeForm = new Employee()
            };

            return View(model);
        }

        // 🔹 POST: Form submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(MainForm model)
        {
            if (ModelState.IsValid)
            {
                await _formService.SaveMainFormAsync(model);
                return RedirectToAction("Success");
            }

            // Validation fail hone par same view wapas
            return View(model);
        }

        // 🔹 Success Page
        public IActionResult Success()
        {
            return View();
        }

      
    }
}
