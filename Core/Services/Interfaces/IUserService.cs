using Core.Entities;

namespace Core.Services.Interfaces;

public interface IUserService
{
    public User GetbyId(int id);


    public void AddUser(User user);

    public void UpdateUser(int id, string? password, string? email);

    public void RemoveUser(int id);



}
