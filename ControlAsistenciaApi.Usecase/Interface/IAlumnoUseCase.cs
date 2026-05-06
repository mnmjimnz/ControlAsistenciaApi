using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IAlumnoUseCase
    {
        Task<List<AlumnoDto>> ObtenerAlumnos();
        Task<AlumnoDto> ObtenerAlumnoPorId(int? id);
        Task<int> GuardarAlumno(AlumnoDto p);
        Task<int> EditarAlumno(AlumnoDto p);
    }
}
