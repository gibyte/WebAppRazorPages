using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public SqlUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User? GetUserById(int id)
        {
            return _appDbContext.Users.Where( u => u.Id == id).ToList().FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _appDbContext.Users.ToList();
        }

        public User UpdateUser(User upUser)
        {
            if (upUser.Id == 0)
            {
                _appDbContext.Users.Add(upUser);
            }
            else
            {
                _appDbContext.Users.Update(upUser);
            }
            _appDbContext.SaveChanges();
            return upUser;
        }
    }
}
