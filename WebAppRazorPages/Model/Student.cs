using System.ComponentModel.DataAnnotations;

namespace WebAppRazorPages.Model
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string Email { get; set; }
        public string LastName { get; set; }
        public List<SubjectGrade> SubjectGrades { get; set; }
        public Student() 
        { 
            Name ??= string.Empty;
            Email ??= string.Empty;
            LastName ??= string.Empty;
            SubjectGrades ??= new();
        }
    }
}
