using System.Security.Authentication;
using AutoMapper;
using Kangaroo.Repository.Abstractions;
using KangarooTest.Models;
using KangarooTest.Persistence;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Kangaroo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;
        public UserRepository(UserDbContext userDbContext, IMapper mapper)
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;

            await _userDbContext.Users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userDbContext.Users.ToListAsync();
        }

        public async Task<AuthenticateUserResponse> AuthenticateAsync(AuthenticateUserRequest authenticateUserRequest)
        {
            var user = _userDbContext.Users.SingleOrDefault(x => x.Username == authenticateUserRequest.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(authenticateUserRequest.Password, user.Password))
                throw new InvalidCredentialException("Username or password is incorrect");

            var response = _mapper.Map<AuthenticateUserResponse>(user);

            return response;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _userDbContext.Users.Update(user);
            await _userDbContext.SaveChangesAsync();

            return user;
        }
    }
}
