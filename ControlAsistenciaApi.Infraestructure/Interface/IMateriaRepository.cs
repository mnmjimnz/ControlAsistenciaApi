using ControlAsistenciaApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure.Interface
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<Materia>> ObtenerMaterias(int PageSize, int PageNumber);
        Task<IEnumerable<Materia>> ObtenerMateriaPorId(int? id);
        Task<int> GuardarMateria(Materia p);
        Task<int> EditarMateria(Materia p);
    }
}
