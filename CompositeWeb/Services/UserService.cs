using HttpResponse = CompositeWeb.Application.Shared.HttpResponse;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.DTOs.Response.User;
using CompositeWeb.Domain.DTOs.Request.User;
using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            user.IsAdult)
        );

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

        var usersFiltered = new ResponseCompletUserDto(
            user.Id,
            user.Name,
            user.Email,
            user.IsAccountEnabled,
            user.DateOfBirth,
            user.IsAdult
        );

        return new HttpResponse(HttpStatusCode.Accepted, usersFiltered);
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

    public async Task<IActionResult> AddBookToFavoriteListAsync(Guid id, RequestBookDtoRegister book)
    {
        var response = await repository.AddBookToFavoriteListAsync(id, book);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest, "User or Book does not exist");

        return new HttpResponse(HttpStatusCode.Accepted, response, "Book was add at the favorite books");
    }

    public async Task<IActionResult> UpdateUser(Guid id, RequestUserDtoUpdate user)
    {
        List<string> propertiesFromObject =
            user.GetType().GetProperties().Where(p => p.Name != "Id").Select(p => p.Name).ToList();

        var response = await repository.UpdateUser(id, user, propertiesFromObject);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest,
                $"The {nameof(user)} is incorrect or does not exit an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, user);
    }

    public async Task<IActionResult> UpdateUserPartialAsync(Guid id, RequestUserDtoUpdate request)
    {
        var user = await repository.UpdateUserPartialAsync(id, request,
            new List<string>()
            {
                request.Name,
                request.Email,
                request.Password
            });
        
        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest, "Somethings goes wrong");

        return new HttpResponse(HttpStatusCode.Accepted, $"{user.Name} was updated");
    }

    public async Task<IActionResult> DisableAccount(Guid id)
    {
        var user = await repository.DisableAccountAsync(id);

        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Does not exit an user with Id:{id}");

        var statusAccount = user.IsAccountEnabled ? "activated" : "deleted";
        return new HttpResponse(HttpStatusCode.Accepted, $"User {user.Name} was {statusAccount}");
    }

    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        var user = await repository.DeleteUserAsync(id);

        if (user is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Something goes wrong");

        return new HttpResponse(HttpStatusCode.Accepted, $"{user.Name} was deleted");
    }
}