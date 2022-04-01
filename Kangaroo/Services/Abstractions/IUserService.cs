using KangarooTest.Models;

namespace KangarooTest.Services.Abstractions
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequest createUserRequest);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task<AuthenticateUserResponse> AuthenticateAsync(AuthenticateUserRequest authenticateUserRequest);
    }
}
