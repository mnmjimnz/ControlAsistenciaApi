using ControlAsistenciaApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure.Interface
{
    public interface IAlumnoRepository
    {
        Task<IEnumerable<Alumno>> ObtenerAlumnos(int PageSize, int PageNumber);
        Task<IEnumerable<Alumno>> ObtenerAlumnosPorNombre(string filtro, int PageSize, int PageNumber);
        Task<IEnumerable<Alumno>> ObtenerAlumnoPorId(int? id);
        Task<int> GuardarAlumno(Alumno p);
        Task<int> EditarAlumno(Alumno p);
    }
}
