using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public class UserController : IUserController
    {
        private List<User> _users;
        public UserController() 
        { 
            _users ??= new List<User>();
            _users.Add(new() { Id = 1, Name = "Первый", Email = "first@first.ru" });
            _users.Add(new() { Id = 2, Name = "Второй", Email = "first@first.ru" });
            _users.Add(new() { Id = 3, Name = "Третий", Email = "first@first.ru" });
        }
        public User? GetUserById(int id) 
        {
            return _users.Where(u => u.Id == id).ToList().FirstOrDefault();            
        }

        public List<User> GetUsers() 
        {
            return _users;
        }

        public User UpdateUser(User upUser) 
        {
            var userDB = GetUserById(upUser.Id);
            if (userDB != null)
            {
                _users.Remove(userDB);
            }
            _users.Add(upUser);
            return upUser;
        }
    }
}
