using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Controller;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class UserModel : PageModel
    {
        private UserController _users = new ();
        public User? User { get; set; }
        public IActionResult OnGet(int id = 1) 
        {
            User = _users.GetUserById(id); // запрашиваем у контроллера пользователся и id из параметра
            if (User == null) return NotFound(); // если пользватель не нашелся выкидываем ошибку HTTP 404
            return Page(); // выводим страницу пользователя
        }
    }
}
