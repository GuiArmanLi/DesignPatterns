using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.data.Repositories;

public class UserRepository(BaseRepository<User> baseRepository) : IUserRepository
{
    public async Task<List<User>> FindAllUsersAsync()
    {
        return await baseRepository.FindAll();
    }

    public Task<User?> FindUserByPropertyAsync(User request)
    {
        return baseRepository.FindByPropertyAsync(u => u.Name == request.Name);
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        return await baseRepository.FindById(id);
    }

    public Task<User?> RegisterUser(User request)
    {
        return baseRepository.RegisterEntityAsync(request, u => u.Email == request.Email);
    }

    public Task<User?> UpdateUser(Guid id, User request)
    {
        return baseRepository.UpdateEntityAsync(id, request);
    }

    // public async Task<User?> UpdateUserPartialAsync(Guid id, Dictionary<string, object> request)
    // {
    //     var user = await baseRepository.FindById(id);
    //
    //     if (user == null)
    //         return null;
    //
    //     var attributes = user.GetType().Attributes;
    //     Console.WriteLine(attributes);
    //
    //     return null;
    // }

    public async Task<User?> DisableAccountAsync(Guid id)
    {
        var user = await baseRepository.FindById(id);

        if (user is null)
            return null;

        user.IsAccountEnabled = !user.IsAccountEnabled;
        return await baseRepository.UpdateEntityAsync(user.Id, user);
    }

    public async Task<User?> DeleteUserAsync(Guid id)
    {
        return await baseRepository.DeleteEntityByIdAsync(id);
    }
}