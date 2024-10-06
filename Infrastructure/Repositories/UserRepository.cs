using Microsoft.EntityFrameworkCore;
using UserRegistrationApi.Domain.Entities;
using UserRegistrationApi.Domain.Interface;
using UserRegistrationApi.Infrastructure.Data;

namespace UserRegistrationApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException("User not found");
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
