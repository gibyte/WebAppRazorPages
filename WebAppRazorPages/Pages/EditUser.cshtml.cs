using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class EditUserModel : PageModel
    {

        public EditUserModel(IUserController userController)
        {
            _userController = userController;
        }

        private IUserController _userController;
        public User? User { get; set; }

        public string? Email { get; set; }
        public string? Name { get; set; }

        public IActionResult OnGet(int id)
        {
            User = _userController.GetUserById(id);
            User ??= new();
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