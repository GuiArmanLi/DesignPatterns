using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.data.Repositories;

public class UserRepository(BaseRepository<User> baseRepository) : IUserRepository
{
    private BaseRepository<User> _baseRepository = baseRepository;

    public async Task<List<User>> GetAllUsers()
    {
        return await _baseRepository.GetAllEntities();
    }

    public Task<User?> GetUserById(Guid request)
    {
        return _baseRepository.GetEntityById(request);
    }

    public Task<User?> PostUser(User request)
    {
        return _baseRepository.PostEntity(request ,new object[] { request.Name });
    }

    public Task<User?> PutUser(Guid id, User request)
    {
        return _baseRepository.PutEntity(id, request);
    }

    public Task<User?> DeleteAccount(Guid request)
    {
        return _baseRepository.DeleteEntity(request);
    }
}