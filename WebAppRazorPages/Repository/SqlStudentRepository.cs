using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public SqlStudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Student DeleteUser(int id)
        {
            var user = GetUserById(id);
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public Student? GetUserById(int id)
        {
            return _appDbContext.Students.Where( u => u.Id == id).ToList().FirstOrDefault();
        }

        public List<Student> GetUsers()
        {
            return _appDbContext.Students.ToList();
        }

        public Student UpdateUser(Student upUser)
        {
            if (upUser.Id == 0)
            {
                _appDbContext.Students.Add(upUser);
            }
            else
            {
                _appDbContext.Students.Update(upUser);
            }
            _appDbContext.SaveChanges();
            return upUser;
        }
    }
}
