using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class StudentModel : PageModel
    {
        public StudentModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        private IStudentRepository _studentRepository;
        public Student? Student { get; set; }
        public IActionResult OnGet(int id = 1) 
        {
            Student = _studentRepository.GetUserById(id); // ����������� � ����������� ������������� � id �� ���������
            if (Student == null) return NotFound(); // ���� ����������� �� ������� ���������� ������ HTTP 404
            return Page(); // ������� �������� ������������
        }
    }
}
