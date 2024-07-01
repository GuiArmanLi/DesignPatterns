using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task GetAllUsers();
    public Task GetUserById(Guid request);
    public Task PostUser(User request);
    public Task PutUser(User request);
    public Task DisableAccount(User request);
}