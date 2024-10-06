using UserRegistrationApi.Domain.Entities;

namespace UserRegistrationApi.Application.Services
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task Update(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task Delete(Guid id);
    }

}
