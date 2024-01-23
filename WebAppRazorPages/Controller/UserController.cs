using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public class UserController
    {
        private List<User> _users;
        public UserController() 
        { 
            _users ??= new List<User>();
            User newUser = new() { Id = 1, Name = "Первый", Email = "first@first.ru" };
            _users.Add(newUser);
        }
        public User? GetUserById(int id) 
        {
            return _users.Where(u => u.Id == id).ToList().FirstOrDefault();            
        }
    }
}
