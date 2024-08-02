using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> FindAllUsersAsync();
    public Task<User?> FindByIdAsync(Guid id);
    public Task<User?> FindUserByPropertyAsync(User user);
    public Task<User?> RegisterUser(User user);
    public Task<User?> AddBookToFavoriteListAsync(Guid id, Book book);
    public Task<User?> UpdateUser(Guid id, User user, List<string> propertiesFromObject);
    public Task<User?> UpdateUserPartialAsync(Guid id, User user, List<string> propertiesFromObject);

    public Task<User?> DisableAccountAsync(Guid id);
    public Task<User?> DeleteUserAsync(Guid id);
}