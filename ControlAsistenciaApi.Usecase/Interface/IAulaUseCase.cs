using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IAulaUseCase
    {
        Task<List<AulaDto>> ObtenerAulas(int PageSize, int PageNumber);
        Task<AulaDto> ObtenerAulaPorId(int? id);
        Task<int> GuardarAula(AulaDto p);
        Task<int> EditarAula(AulaDto p);
    }
}
