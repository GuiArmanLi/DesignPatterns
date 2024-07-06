using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    [HttpGet("/id")]
    public Task<User> GetUserById(Guid request)
    {
        return _userRepository.GetUserById(request);
    }

    [HttpPost]
    public Task<User> PostUser(User request)
    {
        return _userRepository.PostUser(request);
    }

    [HttpPut("/id")]
    public Task<User> PutUser(Guid id, User request)
    {
        return _userRepository.PutUser(id, request);
    }

    [HttpDelete("/id")]
    public Task<User> DeleteAccount(Guid request)
    {
        return _userRepository.DeleteAccount(request);
    }
}