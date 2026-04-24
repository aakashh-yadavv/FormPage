using System.ComponentModel.DataAnnotations;

namespace FormPage.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public int Salary { get; set; }
        public string EmpAddress { get; set; }
    }
}
