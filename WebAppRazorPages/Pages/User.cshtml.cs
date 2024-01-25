using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class UserModel : PageModel
    {

        public UserModel(IUserController userController)
        {
            _userController = userController;
        }
        private IUserController _userController;
        public User? User { get; set; }
        public IActionResult OnGet(int id = 1) 
        {
            User = _userController.GetUserById(id); // ����������� � ����������� ������������� � id �� ���������
            if (User == null) return NotFound(); // ���� ����������� �� ������� ���������� ������ HTTP 404
            return Page(); // ������� �������� ������������
        }
    }
}
