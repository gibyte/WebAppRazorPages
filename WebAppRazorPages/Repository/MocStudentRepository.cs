using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public class MocStudentRepository : IStudentRepository
    {
        private List<Student> _students;
        public MocStudentRepository() 
        {
            _students ??= new List<Student>();
            /*
            List<SubjectGrade> subjectGrade = new() 
            { 
                new SubjectGrade { Name = "Математика", Grade = 5 },
                new SubjectGrade { Name = "Информатика", Grade = 4 },
                new SubjectGrade { Name = "Программирование", Grade = 2 },
                new SubjectGrade { Name = "Английский", Grade = 3 },
            };
            _students.Add(new() { Id = 1, Name = "Первый", Email = "first@first.ru" , SubjectGrades = subjectGrade });
            _students.Add(new() { Id = 2, Name = "Второй", Email = "first@first.ru" });
            _students.Add(new() { Id = 3, Name = "Третий", Email = "first@first.ru" });
            */
        }

        public Student DeleteUser(int id)
        {
            var user = GetUserById(id);
            _students.Remove(user);
            return user;
        }

        public Student? GetUserById(int id) 
        {
            return _students.Where(u => u.Id == id).ToList().FirstOrDefault();            
        }

        public List<Student> GetUsers() 
        {
            return _students;
        }

        public Student UpdateUser(Student upUser) 
        {
            var userDB = GetUserById(upUser.Id);
            if (userDB != null)
            {
                _students.Remove(userDB);
            }
            _students.Add(upUser);
            return upUser;
        }
    }
}
