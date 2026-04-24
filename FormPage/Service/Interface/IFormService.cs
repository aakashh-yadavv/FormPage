
using FormPage.Models;
using FormPage.ViewModel;

namespace FormPage.Service.Interface
{
    public interface IFormService
    {
    
        Task SaveMainFormAsync(MainForm model);
        Task<ShowDetails> GetShowDetailsAsync();

        Task UpdateStudentAsync(Student student);
        Task UpdateEmployeeAsync(Employee employee);

        Task DeleteStudentAsync(int id);
        Task DeleteEmployeeAsync(int id);


    }
}
