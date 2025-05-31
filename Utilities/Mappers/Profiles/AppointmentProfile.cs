using AutoMapper;
using Entity.Dtos.AppointmentDto;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            // Mapeo básico entre entidades
            CreateMap<Appointment, AppointmentDto>().ReverseMap();

            // AutoMapper maneja automáticamente las colecciones
            // No necesitas mapear explícitamente las colecciones
        }
    }
}