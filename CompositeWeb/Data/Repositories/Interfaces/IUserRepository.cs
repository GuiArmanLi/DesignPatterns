using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> FindAllUsers();
    public Task<User?> FindById(Guid request); //add from body
    public Task<User?> FindUserByProperty(User request);
    public Task<User?> RegisterUser(User request);
    public Task<User?> UpdateUser(Guid id, User request);
    public Task<User?> DeleteUser(Guid request);
    public Task<User?> DisableAccount(Guid request);
}