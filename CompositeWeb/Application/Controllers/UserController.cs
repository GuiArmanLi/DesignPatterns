using CompositeWeb.Domain.DTOs;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> FindAllUsers()
    {
        return await _userService.FindAllUsers();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindUserById([FromRoute] Guid id)
    {
        return await _userService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RequestUserDtoRegister request)
    {
        return await _userService.RegisterUserAsync(request);
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateUser(
        [FromRoute] Guid id,
        [FromBody] RequestUserDtoUpdate request)
    {
        return _userService.UpdateUser(id, request);
    }

    /// <summary>
    /// Disable the user
    /// </summary>
    [HttpPatch("{id:guid}")]
    public Task<IActionResult> DisableAccount(Guid id)
    {
        return _userService.DisableAccount(id);
    }


    // [HttpDelete("admin/{id:guid}")]
    // public Task<ResponseUserDTO?> DeleteUser(Guid id)
    // {
    // return _userService.DeleteUserAsync(id);
    // }
}