using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class UsersModel : PageModel
    {
        public UsersModel(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        private IUserRepository _userRepository;
        public List<User> users { get; set; }
        public IActionResult OnGet()
        {
            users = _userRepository.GetUsers();
            return Page();
        }
    }
}
