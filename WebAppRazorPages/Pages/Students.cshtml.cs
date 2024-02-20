using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class StudentsModel : PageModel
    {
        public StudentsModel(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }
        private IStudentRepository _studentRepository;
        public List<Student> Students { get; set; }
        public IActionResult OnGet()
        {
            Students = _studentRepository.GetUsers();
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _studentRepository.DeleteUser(id);
            return RedirectToPage();
        }

    }
}
