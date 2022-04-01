using KangarooTest.Models;

namespace Kangaroo.Repository.Abstractions
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(User user);
        Task<AuthenticateUserResponse> AuthenticateAsync(AuthenticateUserRequest authenticateUserRequest);
    }
}
