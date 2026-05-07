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
            CreateMap<Aula, AulaDto>();
            CreateMap<AulaDto, Aula>();
            CreateMap<Materia, MateriaDto>();
            CreateMap<MateriaDto, Materia>();
            CreateMap<Horario_d, Horario_dDto>();
            CreateMap<Horario_dDto, Horario_d>();
            CreateMap<Horario_h, Horario_hDto>();
            CreateMap<Horario_hDto, Horario_h>();
            CreateMap<Registro_asistencia, Registro_asistenciaDto>();
            CreateMap<Registro_asistenciaDto, Registro_asistencia>();
        }
    }
}
