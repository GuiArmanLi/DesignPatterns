using CompositeWeb.Domain.DTOs;

namespace CompositeWeb.Services.Interfaces;

public interface IUserService
{
    public Task<List<ResponseUserDTO>> FindAllUsers();
    public Task<ResponseUserDTO?> FindByIdAsync(Guid request); //add from body
    public Task<ResponseUserDTO?> FindUserByProperty(RequestUserDtoRegister request);
    public Task<ResponseUserDTO?> RegisterUserAsync(RequestUserDtoRegister request);
    public Task<ResponseUserDTO?> UpdateUser(Guid id, RequestUserDtoUpdate request);

    public Task<ResponseUserDTO?> DisableAccount(Guid id);
    public Task<ResponseUserDTO?> DeleteUserAsync(Guid request);
}