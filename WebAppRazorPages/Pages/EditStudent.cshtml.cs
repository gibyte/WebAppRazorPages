using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    [Authorize]
    public class EditStudentModel : PageModel
    {

        public EditStudentModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        private IStudentRepository _studentRepository;
        public Student? Student { get; set; }
        public IActionResult OnGet(int id)
        {
            Student = _studentRepository.GetUserById(id);
            Student ??= new();
            return Page();
        }

        public IActionResult OnPost(Student? studentForm)
        {
            
            var userDB = _studentRepository.UpdateUser(studentForm);
            if (userDB == null) return NotFound();
            return RedirectToPage("Students");
        }
    }
}