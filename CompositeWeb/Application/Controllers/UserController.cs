using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public Task<List<User>> FindAllUsers()
    {
        return userRepository.FindAllUsers();
    }

    [HttpGet("{id:guid}")]
    public Task<User?> FindUserById(Guid request)
    {
        return userRepository.FindById(request);
    }

    [HttpPost]
    public Task<User?> RegisterUser(User request)
    {
        return userRepository.RegisterUser(request);
    }

    [HttpPut("{id:guid}")]
    public Task<User?> UpdateUser(Guid id, User request)
    {
        return userRepository.UpdateUser(id, request);
    }

    [HttpDelete("admin/{id:guid}")]
    public Task<User?> DeleteUser(Guid request)
    {
        return userRepository.DeleteUser(request);
    }

    [HttpDelete("{id:guid}")]
    public Task<User?> DisableAccount(Guid request)
    {
        return userRepository.DisableAccount(request);
    }
}