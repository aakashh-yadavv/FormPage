using FormPage.Data;
using FormPage.Models;
using FormPage.Service.Interface;
using FormPage.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Service.Implement
{
    public class FormService:IFormService
    {
        private readonly PersonalDbClass _context;

        public FormService(PersonalDbClass context)
        {
            _context = context;
        }

        public async Task<ShowDetails> GetShowDetailsAsync()
        {
            ShowDetails details = new ShowDetails();

            details.Students = await _context.Students.ToListAsync();
            details.Employees = await _context.Employees.ToListAsync();
           
            return details ;
        }

        public async Task SaveMainFormAsync(MainForm model)
        {
            if (model.EmployeeForm != null)
            {
                await _context.Employees.AddAsync(model.EmployeeForm);
            }

            if (model.StudentForm != null)
            {
                await _context.Students.AddAsync(model.StudentForm);
            }

            await _context.SaveChangesAsync();
        }


        public async Task UpdateStudentAsync(Student student)
        {
            var existing = await _context.Students.FindAsync(student.StudentID);

            if (existing != null)
            {
                existing.StudentName = student.StudentName;
                existing.StudentAge = student.StudentAge;
                existing.StudentAddress = student.StudentAddress;
                existing.SchoolName = student.SchoolName;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existing = await _context.Employees.FindAsync(employee.EmpId);

            if (existing != null)
            {
                existing.EmpName = employee.EmpName;
                existing.EmpAge = employee.EmpAge;
                existing.Salary = employee.Salary;
                existing.EmpAddress = employee.EmpAddress;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
