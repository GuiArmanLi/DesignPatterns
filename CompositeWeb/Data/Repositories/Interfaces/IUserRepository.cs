using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUserById(Guid request);
    public Task<User> PostUser(User request);
    public Task<User> PutUser(Guid id, User request);
    public Task<User> DeleteAccount(Guid request);
}