using UserRegistrationApi.Domain.Entities;
using UserRegistrationApi.Domain.Interface;

namespace UserRegistrationApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Create(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }
    }
}
