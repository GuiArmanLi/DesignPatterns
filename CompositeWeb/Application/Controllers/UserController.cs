using CompositeWeb.data.Repositories;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public Task GetUsers()
    {
        return _userRepository.GetAllUsers();
    }

    [HttpPost]
    public Task PostUser(User request)
    {
        return _userRepository.PostUser(request);
    }

    [HttpPut]
    public Task PutUser(User request)
    {
        return _userRepository.PutUser(request);
    }

    [HttpDelete]
    public Task DisableAccount(User request)
    {
        return _userRepository.DisableAccount(request);
    }
}