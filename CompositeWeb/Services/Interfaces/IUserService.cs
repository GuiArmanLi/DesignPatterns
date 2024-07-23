using CompositeWeb.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Services.Interfaces;

public interface IUserService
{
    public Task<IActionResult> FindAllUsers();
    public Task<IActionResult> FindByIdAsync(Guid request); //add from body
    public Task<IActionResult> FindUserByProperty(RequestUserDtoRegister request);
    public Task<IActionResult> RegisterUserAsync(RequestUserDtoRegister request);
    public Task<IActionResult> UpdateUser(Guid id, RequestUserDtoUpdate request);

    public Task<IActionResult> DisableAccount(Guid id);
    // public Task<IActionResult> DeleteUserAsync(Guid request);
}