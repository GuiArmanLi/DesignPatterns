using CompositeWeb.Domain.DTOs;
using CompositeWeb.Domain.DTOs.Request.User;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Services.Interfaces;

public interface IUserService
{
    public Task<IActionResult> FindAllUsersAsync();
    public Task<IActionResult> FindAllUsersSummariesAsync();
    public Task<IActionResult> FindByIdAsync(Guid request); //add from body
    public Task<IActionResult> FindUserByProperty(RequestUserDtoRegister request);
    public Task<IActionResult> RegisterUserAsync(RequestUserDtoRegister request);
    public Task<IActionResult> UpdateUser(Guid id, RequestUserDtoUpdate request);

    public Task<IActionResult> DisableAccount(Guid id);
    // public Task<IActionResult> DeleteUserAsync(Guid request);
}