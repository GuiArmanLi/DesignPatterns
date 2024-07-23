using System.Net;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.DTOs;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HttpResponse = CompositeWeb.Application.Shared.HttpResponse;

namespace CompositeWeb.Services;

public class UserService : IUserService


{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<IActionResult> FindAllUsers()
    {
        var users = await _userRepository.FindAllUsersAsync();

        if (users.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any user");

        var usersFiltered = users.Select(user => new ResponseUserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            IsAdult = user.IsAdult,
            IsAccountEnabled = user.IsAccountEnabled,
            FavoriteBookId = user.FavoriteBookId
        }).ToList();

        return new HttpResponse(HttpStatusCode.OK, usersFiltered);
    }

    public async Task<IActionResult> FindByIdAsync(Guid id)
    {
        var user = await _userRepository.FindByIdAsync(id);

        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Does not exist an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, user);
    }

    public async Task<IActionResult> FindUserByProperty(RequestUserDtoRegister request)
    {
        var user = await _userRepository.FindUserByPropertyAsync(request);
        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest);

        return new HttpResponse(HttpStatusCode.OK, user);
    }

    public async Task<IActionResult> RegisterUserAsync(RequestUserDtoRegister request)
    {
        var response = await _userRepository.RegisterUser(request);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest, "User already exist");

        return new HttpResponse(HttpStatusCode.Created, response);
    }

    public async Task<IActionResult> UpdateUser(Guid id, RequestUserDtoUpdate request)
    {
        var user = await _userRepository.UpdateUser(id, request);
        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest,
                $"The {nameof(request)} is incorrect or does not exit an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, user);
    }

    // public async Task<ResponseUserDTO?> UpdateUserPartialAsync(Guid id, RequestUserDTO request)
    // {
    //     _userRepository.UpdateUserPartialAsync(id, request);
    //     return null;
    // }

    public async Task<IActionResult> DisableAccount(Guid id)
    {
        var user = await _userRepository.DisableAccountAsync(id);

        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Does not exit an user with Id:{id}");

        var statusAccount = user.IsAccountEnabled ? "activated" : "deleted";
        return new HttpResponse(HttpStatusCode.Accepted, $"User {user.Name} was {statusAccount}");
    }

    // public async Task<IActionResult> DeleteUserAsync(Guid id)
    // {
    // return await _userRepository.DeleteUserAsync(id) ??
    // throw new ArgumentNullException($"{nameof(id)} invalid");
    // return null;
    // }
}