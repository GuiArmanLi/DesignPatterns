using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.data.Repositories;

public class UserRepository(BaseRepository<User> baseRepository) : IUserRepository
{
    public Task<List<User>> FindAllUsers()
    {
        return baseRepository.FindAll();
    }

    public Task<User?> FindUserByProperty(User request)
    {
        return baseRepository.FindByProperty(u => u.Name == request.Name);
    }

    public Task<User?> FindById(Guid id)
    {
        return baseRepository.FindById(id);
    }

    public Task<User?> FindByProperty(User request)
    {
        return baseRepository.FindByProperty(u => u.Name == request.Name);
    }

    public Task<User?> RegisterUser(User request)
    {
        return baseRepository.RegisterEntity(request, u => u.Email == request.Email);
    }

    public Task<User?> UpdateUser(Guid id, User request)
    {
        return baseRepository.UpdateEntity(id, request);
    }

    public Task<User?> DeleteUser(Guid request)
    {
        return baseRepository.DeleteEntityById(request);
    }

    public async Task<User?> DisableAccount(Guid request)
    {
        var entity = await baseRepository.FindById(request);

        if (entity == null) throw new Exception("Usuario nulo"); // Fazer execao especifica

        entity.IsAccountEnabled = !entity.IsAccountEnabled;
        await baseRepository.UpdateEntity(entity.Id, entity); //Desabilitar o campo

        return entity;
    }
}