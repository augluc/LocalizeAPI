using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User GetbyId(int id);

        public User GetByUsername(string username);

        public void AddUser(User user);

        public void UpdateUser(int id, string? password, string? email);

        public void RemoveUser(int id);
    }
}
