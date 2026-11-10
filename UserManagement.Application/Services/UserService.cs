
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    #region [ Ctor ] 
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    #region [ Delete ]
    public async Task Delete(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }
        await _userRepository.Delete(user);
    }
    #endregion

    #region [ Create ]
    public async Task CreateAsync(UserDto user)
    {
        var newUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName
        };
        await _userRepository.CreateAsync(newUser);
    }
    #endregion

    #region [ GetAll ]
    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(user => new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        }).ToList();
    }
    #endregion

    #region [ GetById ]
    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
    #endregion
}
