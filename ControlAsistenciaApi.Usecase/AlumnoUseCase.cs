using AutoMapper;
using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Infraestructure.Interface;
using ControlAsistenciaApi.Usecase.Interface;

namespace ControlAsistenciaApi.Usecase
{
    public class AlumnoUseCase: IAlumnoUseCase
    {
        private readonly IAlumnoRepository _repoAlumno;
        private readonly IMapper _mapper;
        public AlumnoUseCase(IAlumnoRepository repoA, IMapper map)
        {
            _repoAlumno = repoA;
            _mapper = map;
        }

        public async Task<List<AlumnoDto>> ObtenerAlumnos(int PageSize, int PageNumber)
        {
            try
            {
                var r = await _repoAlumno.ObtenerAlumnos(PageSize, PageNumber);
                return _mapper.Map<List<AlumnoDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<AlumnoDto>();
            }
        }
        public async Task<List<AlumnoDto>> ObtenerAlumnosPorNombre(string filtro, int PageSize, int PageNumber)
        {
            try
            {
                var r = await _repoAlumno.ObtenerAlumnosPorNombre(filtro, PageSize, PageNumber);
                return _mapper.Map<List<AlumnoDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<AlumnoDto>();
            }
        }
        public async Task<AlumnoDto> ObtenerAlumnoPorId(int? id)
        {
            try
            {
                var r = await _repoAlumno.ObtenerAlumnoPorId(id);
                return _mapper.Map<AlumnoDto>(r.SingleOrDefault());
            }
            catch (Exception  ex)
            {
                return new AlumnoDto();
            }
        }
        public async Task<int> GuardarAlumno(AlumnoDto p)
        {
            try
            {
                var o = _mapper.Map<Alumno>(p);
                return await _repoAlumno.GuardarAlumno(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarAlumno(AlumnoDto p)
        {
            try
            {
                var o = _mapper.Map<Alumno>(p);
                return await _repoAlumno.EditarAlumno(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
