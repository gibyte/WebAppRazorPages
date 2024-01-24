using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class UsersModel : PageModel
    {
        private UserController _userController = new();
        public List<User> users { get; set; }
        public IActionResult OnGet()
        {
            users = _userController.GetUsers();
            return Page();
        }
    }
}
