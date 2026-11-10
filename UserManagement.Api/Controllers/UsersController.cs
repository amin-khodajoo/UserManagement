using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Services;

namespace UserManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    #region [ Ctor ]
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region [ Delete ]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromBody]int id)
    {
        await _userService.Delete(id);

        return Ok(new
        {
            message = "User deleted successfully."
        });
    }
    #endregion

    #region [ Post ]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDto user)
    {
        await _userService.CreateAsync(user);

        return Ok(user);
    }
    #endregion

    #region [ GetAll ]
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();

        return Ok(users);
    }
    #endregion

    #region [ GetById ]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
    #endregion
}
