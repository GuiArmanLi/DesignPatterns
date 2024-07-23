using CompositeWeb.Domain.DTOs;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> FindAllUsersAsync();
    public Task<User?> FindByIdAsync(Guid request);
    public Task<User?> FindUserByPropertyAsync(User request);
    public Task<User?> RegisterUser(User request);
    public Task<User?> UpdateUser(Guid id, User request);
    // public Task<User?> UpdateUserPartialAsync(Guid id, Dictionary<string, object> request);

    public Task<User?> DisableAccountAsync(Guid id);
    public Task<User?> DeleteUserAsync(Guid request);
}