using FormPage.Models;
using FormPage.Service.Interface;
using FormPage.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IFormService _formService;

        public DashboardController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _formService.GetShowDetailsAsync();
            return View(data);
        }
        // 📊 MAIN PAGE (LIST + EDIT SUPPORT)
        [HttpGet]
        public async Task<IActionResult> Index(int? editStudentId, int? editEmpId)
        {
            var students = (await _formService.GetShowDetailsAsync()).Students;
            var employees = (await _formService.GetShowDetailsAsync()).Employees;

            var model = new ShowDetails
            {
                Students = students,
                Employees = employees,

                // ✏ EDIT DATA LOAD
                EditStudent = editStudentId != null
                    ? students.FirstOrDefault(x => x.StudentID == editStudentId)
                    : null,

                EditEmployee = editEmpId != null
                    ? employees.FirstOrDefault(x => x.EmpId == editEmpId)
                    : null
            };

            return View(model);
        }

        // 🎓 UPDATE STUDENT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(Student model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _formService.UpdateStudentAsync(model);

            return RedirectToAction("Index");
        }

        // 👨‍💼 UPDATE EMPLOYEE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _formService.UpdateEmployeeAsync(model);

            return RedirectToAction("Index");
        }
        //-----------Student Edit/Delete----------------
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditStudent(Student model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // wapas dashboard load karo with data
        //        var vm = new ShowDetails
        //        {
        //            Students = (await _formService.GetShowDetailsAsync()).Students,
        //            Employees = (await _formService.GetShowDetailsAsync()).Employees,
        //            EditStudent = model
        //        };
        //        return View("Index", vm);
        //    }

        //    await _formService.UpdateStudentAsync(model);

        //    return RedirectToAction("Index");
        //}
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _formService.DeleteStudentAsync(id);
            return RedirectToAction("Index");
        }


        //-----------Employee Edit/Delete----------------



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditEmployee(Employee model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var vm = new ShowDetails
        //        {
        //            Students = (await _formService.GetShowDetailsAsync()).Students,
        //            Employees = (await _formService.GetShowDetailsAsync()).Employees,
        //            EditEmployee = model
        //        };
        //        return View("Index", vm);
        //    }

        //    await _formService.UpdateEmployeeAsync(model);

        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _formService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
