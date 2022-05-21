using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface IUserRepository
{
    void Save(User user);
    Guid? Authenticate(string email, string password);
    Task<User> Get(Guid id);
    Task<IEnumerable<User>> Get();
}