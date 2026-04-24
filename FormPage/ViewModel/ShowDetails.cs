using FormPage.Models;

namespace FormPage.ViewModel
{
    public class ShowDetails
    {
        public List<Student> Students { get; set; }
        public List<Employee> Employees { get; set; }
        public Student? EditStudent { get; set; }
        public Employee? EditEmployee { get; set; }
    }

  
}
