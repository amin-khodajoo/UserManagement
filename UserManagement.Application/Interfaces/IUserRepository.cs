using UserManagement.Domain.Entities;

namespace UserManagement.Application.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
}

