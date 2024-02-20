using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public interface IStudentRepository
    {
        public Student? GetUserById(int id); // Получить пользователя по идентификатору
        public List<Student> GetUsers(); // Получить список всех пользователей
        public Student UpdateUser(Student upUser); // Обновить информацию о пользователе
        public Student DeleteUser(int id);
    }
}
