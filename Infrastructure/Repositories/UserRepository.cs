using Core.Entities;
using Core.Repositories.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            var userDb = new UserDb(user.Username, user.Password, user.Email);

            _context.Users.Add(userDb);
            _context.SaveChanges();
        }

        public User GetbyId(int id)
        {
            var userDb = _context.Users.Where(user => user.Id == id).FirstOrDefault();

            if (userDb == null) return null;

            User user = new(userDb.Username, userDb.Password, userDb.Email);

            return user;
        }

        public void RemoveUser(int id)
        {
            var userDb = _context.Users.Where(user => user.Id == id).FirstOrDefault();
            if (userDb == null) return;
            _context.Users.Remove(userDb); 
            _context.SaveChanges();
        }

        public void UpdateUser(int id, string? password, string? email)
        {
            var userDb = _context.Users.Where(user => user.Id == id).FirstOrDefault();
            
            if (userDb == null) return;

            if (!string.IsNullOrEmpty(password)) userDb.Password = password;

            if (!string.IsNullOrEmpty(email)) userDb.Email = email;

            _context.SaveChanges();
        }
    }
}
