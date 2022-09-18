using AutoMapper;

namespace API.CoreSystem.Manager.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Domain.DTO.Person, Domain.Entities.Person>().ReverseMap();
        }
    }
}
