using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public interface IUserRepository
    {
        public User? GetUserById(int id); // Получить пользователя по идентификатору
        public List<User> GetUsers(); // Получить список всех пользователей
        public User UpdateUser(User upUser); // Обновить информацию о пользователе
    }
}
