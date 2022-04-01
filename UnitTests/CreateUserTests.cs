using AutoFixture;
using AutoMapper;
using Kangaroo.Repository.Abstractions;
using KangarooTest.Services;
using KangarooTest.Services.Abstractions;
using Moq;
using System.Threading.Tasks;
using KangarooTest.Models;
using Xunit;

namespace UnitTests
{
    public class CreateUserTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Fixture _fixture;
        private readonly IUserService _userService;
        public CreateUserTests()
        {
            _fixture = new Fixture();

            _userRepository = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
            _userService = new UserService(_userRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task CreateUserSuccessfully()
        {
            //Arrange
            var request = _fixture.Create<CreateUserRequest>();
            var user = _fixture.Create<User>();

            _mapper.Setup(m => m.Map<User>(request))
                .Returns(user);

            var createdUser = _fixture.Create<User>();
            _userRepository.Setup(r => r.CreateAsync(user))
                .ReturnsAsync(createdUser);

            //Act
            await _userService.CreateAsync(request);

            //Assert
            _userRepository.Verify(m => m.CreateAsync(user), Times.Once);
        }
    }
}