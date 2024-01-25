using System.Collections.Immutable;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public class SqlUserController : IUserController
    {
        private readonly AppDbContext _appDbContext;

        public SqlUserController(AppDbContext appDbContext)
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
