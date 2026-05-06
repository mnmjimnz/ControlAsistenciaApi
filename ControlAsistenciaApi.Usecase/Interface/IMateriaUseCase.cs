using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IMateriaUseCase
    {
        Task<List<MateriaDto>> ObtenerMaterias();
        Task<MateriaDto> ObtenerMateriaPorId(int? id);
        Task<int> GuardarMateria(MateriaDto p);
        Task<int> EditarMateria(MateriaDto p);
    }
}
