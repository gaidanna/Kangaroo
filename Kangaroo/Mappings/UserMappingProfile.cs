using AutoMapper;
using KangarooTest.Models;

namespace KangarooTest.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
