using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task CreateAsync(UserDto user);
    Task Delete(int id);
}
