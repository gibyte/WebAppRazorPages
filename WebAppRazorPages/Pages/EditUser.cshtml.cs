using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class EditUserModel : PageModel
    {

        public EditUserModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private IUserRepository _userRepository;
        public User? User { get; set; }

        public string? Email { get; set; }
        public string? Name { get; set; }

        public IActionResult OnGet(int id)
        {
            User = _userRepository.GetUserById(id);
            User ??= new();
            return Page();
        }

        public IActionResult OnPost(User? userForm)
        {
            
            var userDB = _userRepository.UpdateUser(userForm);
            if (userDB == null) return NotFound();
            return Page();
        }
    }
}