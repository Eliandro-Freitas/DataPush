using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface IUserRepository
{
    void Save(User user);
    Task<bool> Authenticate(string email, string password);
    Task<User> Get(Guid id);
    Task<IEnumerable<User>> Get();
}