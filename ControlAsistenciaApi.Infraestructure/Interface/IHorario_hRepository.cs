using ControlAsistenciaApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure.Interface
{
    public interface IHorario_hRepository
    {
        Task<IEnumerable<Horario_h>> ObtenerHorario_h();
        Task<IEnumerable<Horario_h>> ObtenerHorario_hPorId(int? id);
        Task<int> GuardarHorario_h(Horario_h p);
        Task<int> EditarHorario_h(Horario_h p);
    }
}
