using CompositeWeb.Domain.DTOs;
using CompositeWeb.Domain.DTOs.Request.User;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service)
{
    [HttpGet]
    public Task<IActionResult> FindAllUsers()
    {
        return service.FindAllUsersAsync();
    }

    [HttpGet("summaries")]
    public Task<IActionResult> FindAllUsersSummaries()
    {
        return service.FindAllUsersSummariesAsync();
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> FindUserById([FromRoute] Guid id)
    {
        return service.FindByIdAsync(id);
    }

    [HttpPost]
    public Task<IActionResult> RegisterUser([FromBody] RequestUserDtoRegister request)
    {
        return service.RegisterUserAsync(request);
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateUser(
        [FromRoute] Guid id,
        [FromBody] RequestUserDtoUpdate request)
    {
        return service.UpdateUser(id, request);
    }

    /// <summary>
    /// Disable the user
    /// </summary>
    [HttpPatch("{id:guid}")]
    public Task<IActionResult> DisableAccount(Guid id)
    {
        return service.DisableAccount(id);
    }


    // [HttpDelete("admin/{id:guid}")]
    // public Task<ResponseUserDTO?> DeleteUser(Guid id)
    // {
    // return _userService.DeleteUserAsync(id);
    // }
}