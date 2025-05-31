using AutoMapper;
using Entity.Model;
using Entity.Dtos.DoctorDto;

namespace Utilities.Mappers.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            // Mapeo entre Doctor y DoctorDto
            CreateMap<Doctor, DoctorDto>().ReverseMap();
        }
    }
}
