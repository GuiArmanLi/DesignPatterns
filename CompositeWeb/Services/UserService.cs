using System.Net;
using HttpResponse = CompositeWeb.Application.Shared.HttpResponse;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.DTOs.Response.User;
using CompositeWeb.Domain.DTOs.Request.User;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<IActionResult> FindAllUsersAsync()
    {
        var users = await repository.FindAllUsersAsync();

        if (users.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any user");

        var usersFiltered = users.Select(user => new ResponseCompletUserDto(
            user.Id,
            user.Name,
            user.Email,
            user.IsAccountEnabled,
            user.DateOfBirth,
            user.IsAdult,
            user.FavoriteBookId
        )).ToList();

        return new HttpResponse(HttpStatusCode.OK, usersFiltered);
    }

    public async Task<IActionResult> FindAllUsersSummariesAsync()
    {
        var users = await repository.FindAllUsersAsync();

        if (users.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any user");

        var usersFiltered = users.Select(user => new ResponsePartialUserDto(
            user.Id,
            user.Name,
            user.Email,
            user.IsAccountEnabled
        )).ToList();

        return new HttpResponse(HttpStatusCode.OK, usersFiltered);
    }

    public async Task<IActionResult> FindByIdAsync(Guid id)
    {
        var user = await repository.FindByIdAsync(id);

        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Does not exist an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, user);
    }

    public async Task<IActionResult> FindUserByProperty(RequestUserDtoRegister request)
    {
        var user = await repository.FindUserByPropertyAsync(request);
        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest);

        return new HttpResponse(HttpStatusCode.OK, user);
    }

    public async Task<IActionResult> RegisterUserAsync(RequestUserDtoRegister user)
    {
        var response = await repository.RegisterUser(user);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"User with email: {user.Email} already exist");

        return new HttpResponse(HttpStatusCode.Created, response);
    }

    public async Task<IActionResult> UpdateUser(Guid id, RequestUserDtoUpdate user)
    {
        var response = await repository.UpdateUser(id, user);
        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest,
                $"The {nameof(user)} is incorrect or does not exit an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, user);
    }

// public async Task<ResponseUserDTO?> UpdateUserPartialAsync(Guid id, RequestUserDTO request)
// {
//     _userRepository.UpdateUserPartialAsync(id, request);
//     return null;
// }

    public async Task<IActionResult> DisableAccount(Guid id)
    {
        var user = await repository.DisableAccountAsync(id);

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