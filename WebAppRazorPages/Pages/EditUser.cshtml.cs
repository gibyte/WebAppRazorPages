using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class EditUserModel : PageModel
    {
        private UserController _userController = new();
        public User? User { get; set; }

        public string? Email { get; set; }
        public string? Name { get; set; }

        public IActionResult OnGet(int id)
        {
            User = _userController.GetUserById(id);
            if (User == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost(User? userForm)
        {
            var userDB = _userController.UpdateUser(userForm);
            if (userDB == null) return NotFound();
            return Page();
        }
    }
}