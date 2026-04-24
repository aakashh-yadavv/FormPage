using System.ComponentModel.DataAnnotations;

namespace FormPage.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentAddress { get; set; }
        public string SchoolName { get; set; }
    }
}
