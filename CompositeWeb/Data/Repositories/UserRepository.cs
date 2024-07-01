using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.data.Repositories;

public class UserRepository(BaseRepository<User> baseRepository) : IUserRepository
{
    private BaseRepository<User> _baseRepository = baseRepository;

    public Task GetAllUsers()
    {
        return _baseRepository.GetAllEntitiesQueryable();
    }

    public Task GetUserById(Guid request)
    {
        return _baseRepository.GetEntityByAttribute(request);
    }

    public Task PostUser(User request)
    {
        return _baseRepository.PostEntity(request);
    }

    public Task PutUser(User request)
    {
        return _baseRepository.PutEntity(request);
    }

    public Task DisableAccount(User request) // Arrumar
    {
        return null;
    }
}