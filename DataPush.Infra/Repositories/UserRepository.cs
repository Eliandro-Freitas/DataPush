using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
        => _context = context;

    public async Task<User> Get(Guid id)
        => await _context.Set<User>().FirstOrDefaultAsync(x => id.Equals(x.Id));

    public async Task<IEnumerable<User>> Get()
        => await _context.Set<User>().ToArrayAsync();

    public void Save(User user) 
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    public async Task<bool> Authenticate(string email, string password)
        =>  await _context.Set<User>()
            .AnyAsync(x => email == x.Email 
                   && password == x.Password);
}