using AutoMapper;
using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;

namespace ControlAsistenciaApi.Usecase.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Alumno, AlumnoDto>();
            CreateMap<AlumnoDto, Alumno>();
        }
    }
}
