using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data;

namespace UserManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    #region [ Ctor ]
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ Patch ]
   public async Task Patch(User user)
    {
        _context.SaveChanges();
    }
    #endregion

    #region [ PUT ]
    public async Task Put(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region [ Delete ]
    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region [ Create ]
    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region [ GetAll ]
    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }
    #endregion
    
    #region [ GetById ]
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    #endregion
}
