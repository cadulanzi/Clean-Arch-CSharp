using UserRegistrationApi.Domain.Entities;

namespace UserRegistrationApi.Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task Delete(Guid id);
        Task Update(User user);
    }
}
