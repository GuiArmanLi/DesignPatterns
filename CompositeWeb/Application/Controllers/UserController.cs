using CompositeWeb.Domain.DTOs;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase //adicionar metodo para patch
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public Task<List<ResponseUserDTO>> FindAllUsers()
    {
        return _userService.FindAllUsers();
    }

    [HttpGet("{id:guid}")]
    public Task<ResponseUserDTO?> FindUserById([FromRoute] Guid id) //testar anotacao
    {
        return _userService.FindByIdAsync(id);
    }

    [HttpPost]
    public Task<ResponseUserDTO?> RegisterUser([FromBody] RequestUserDtoRegister request)
    {
        return _userService.RegisterUserAsync(request);
    }

    [HttpPut("{id:guid}")]
    public Task<ResponseUserDTO?> UpdateUser(Guid id, [FromBody] RequestUserDtoUpdate request)
    {
        return _userService.UpdateUser(id, request);
    }


    [HttpDelete("{id:guid}")]
    public Task<ResponseUserDTO?> DisableAccount(Guid id)
    {
        return _userService.DisableAccount(id);
    }


    // [HttpDelete("admin/{id:guid}")]
    // public Task<ResponseUserDTO?> DeleteUser(Guid id)
    // {
    // return _userService.DeleteUserAsync(id);
    // }
}