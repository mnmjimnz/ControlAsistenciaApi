using ControlAsistenciaApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure.Interface
{
    public interface IAulaRepository
    {
        Task<IEnumerable<Aula>> ObtenerAulas();
        Task<IEnumerable<Aula>> ObtenerAulaPorId(int? id);
        Task<int> GuardarAula(Aula p);
        Task<int> EditarAula(Aula p);
    }
}
