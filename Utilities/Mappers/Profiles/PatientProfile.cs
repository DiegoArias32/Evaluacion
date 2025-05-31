using AutoMapper;
using Entity.Dtos.PatientDto;
using Entity.Model;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        // Solo necesitas el mapeo básico
        CreateMap<Patient, PatientDto>().ReverseMap();

        // AutoMapper maneja automáticamente las colecciones
        // No necesitas mapear explícitamente las colecciones
    }
}