using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Real_Estate_Management_System_düzenleme.Controllers;

namespace Real_Estate_Management_System_düzenleme.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
        }
    }

}
