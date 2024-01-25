using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public interface IUserController
    {
        public User? GetUserById(int id);
        public List<User> GetUsers();
        public User UpdateUser(User upUser);
    }
}
