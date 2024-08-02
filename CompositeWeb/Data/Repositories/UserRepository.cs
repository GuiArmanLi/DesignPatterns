using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.data.Repositories;

public class UserRepository(BaseRepository<User> baseRepository) : IUserRepository
{
    public async Task<List<User>> FindAllUsersAsync()
    {
        return await baseRepository.FindAll();
    }

    public Task<User?> FindUserByPropertyAsync(User user)
    {
        return baseRepository.FindByPropertyAsync(u => u.Name == user.Name);
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        return await baseRepository.FindById(id);
    }

    public Task<User?> RegisterUser(User user)
    {
        return baseRepository.RegisterEntityAsync(user, u => u.Email == user.Email);
    }

    public Task<User?> UpdateUser(Guid id, User user, List<string> propertiesFromObject)
    {
        return baseRepository.UpdateEntityAsync(id, user, propertiesFromObject);
    }

    public async Task<User?> UpdateUserPartialAsync(Guid id, User user, List<string> propertiesFromObject)
    {
        var response = await baseRepository.FindById(id);

        if (response is null)
            return null;

        return await baseRepository.UpdateEntityAsync(user.Id, user, propertiesFromObject);
    }

    public async Task<User?> DisableAccountAsync(Guid id)
    {
        var user = await baseRepository.FindById(id);

        if (user is null)
            return null;

        user.IsAccountEnabled = !user.IsAccountEnabled;
        return await baseRepository.UpdateEntityAsync(user.Id, user,
            new List<string>() { user.IsAccountEnabled.ToString() });
    }

    public async Task<User?> AddBookToFavoriteListAsync(Guid id, Book book)
    {
        var user = await baseRepository.FindById(id); // Adicionar condicao se book == null

        if (user == null)
            return null;

        user.FavoriteBooks.Add(book);

        return await baseRepository.UpdateEntityAsync(user.Id, user, new List<string>()
        {
            user.FavoriteBooks.ToString()!
        });
    }

    public async Task<User?> DeleteUserAsync(Guid id)
    {
        return await baseRepository.DeleteEntityByIdAsync(id);
    }
}