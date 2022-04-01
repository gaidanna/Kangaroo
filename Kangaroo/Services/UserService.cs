using AutoMapper;
using Kangaroo.Repository.Abstractions;
using KangarooTest.Models;
using KangarooTest.Services.Abstractions;

namespace KangarooTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
            //return _userDbContext.Users.AsQueryable();
        }

        public async Task<AuthenticateUserResponse> AuthenticateAsync(AuthenticateUserRequest authenticateUserRequest)
        {
            //var user = _userDbContext.Users.SingleOrDefault(x => x.Username == authenticateUserRequest.Username);

            //if (user == null)//validate password here || !BCrypt.Verify(model.Password, user.Password))
            //    throw new AppException("Username or password is incorrect");

            //// authentication successful
            //var response = _mapper.Map<AuthenticateUserResponse>(user);
            //response.Token = _jwtUtils.GenerateToken(user);
            //return response;
            return new AuthenticateUserResponse();
        }

        public async Task<User> CreateAsync(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<User>(createUserRequest);
            var result = await _userRepository.CreateAsync(user);
            return result;
        }

        public async Task<User> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            var user = _mapper.Map<User>(updateUserRequest);
            var result = await _userRepository.UpdateAsync(user);
            return result;
        }
    }
}
