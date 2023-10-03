using AutoMapper;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<RegisterWithRoleDto, User>();
            CreateMap<MakineDto, Makine>();

        }
    }
}
