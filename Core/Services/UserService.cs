using Core.Entities;
using Core.Exceptions;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;

namespace Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(User user)
    {
        //TODO: Validar a adição de usuários repetidos (sugestão: checar por um GET)
        _userRepository.AddUser(user);
    }

    public User GetbyId(int id)
    {
        var response = _userRepository.GetbyId(id);

        if (response == null) throw new NotFoundException();

        return response;
    }

    public User GetByUsername(string username)
    {
        return _userRepository.GetByUsername(username);
    }

    public void RemoveUser(int id)
    {
        if (_userRepository.GetbyId(id) == null) throw new NotFoundException();

        _userRepository.RemoveUser(id);
    }

    public void UpdateUser(int id, string? password, string? email)
    {
        if (_userRepository.GetbyId(id) == null) throw new NotFoundException();
        _userRepository.UpdateUser(id, password, email);
    }
}
