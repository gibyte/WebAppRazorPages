using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public class MocUserRepository : IUserRepository
    {
        private List<User> _users;
        public MocUserRepository() 
        { 
            _users ??= new List<User>();
            List<SubjectGrade> subjectGrade = new() 
            { 
                new SubjectGrade { Name = "Математика", Grade = 5 },
                new SubjectGrade { Name = "Информатика", Grade = 4 },
                new SubjectGrade { Name = "Программирование", Grade = 2 },
                new SubjectGrade { Name = "Английский", Grade = 3 },
            };
            _users.Add(new() { Id = 1, Name = "Первый", Email = "first@first.ru" , SubjectGrades = subjectGrade });
            _users.Add(new() { Id = 2, Name = "Второй", Email = "first@first.ru" });
            _users.Add(new() { Id = 3, Name = "Третий", Email = "first@first.ru" });



        }

        public User DeleteUser(int id)
        {
            var user = GetUserById(id);
           _users.Remove(user);
            return user;
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
