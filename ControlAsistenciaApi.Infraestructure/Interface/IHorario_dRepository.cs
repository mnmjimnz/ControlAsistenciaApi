using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure.Interface
{
    public interface IHorario_dRepository
    {
        Task<IEnumerable<Horario_d>> ObtenerHorario_d();
        Task<IEnumerable<Horario_d>> ObtenerHorario_dPorId(int? id);
        Task<int> GuardarHorario_d(Horario_d p);
        Task<int> EditarHorario_d(Horario_d p);
        Task<IEnumerable<JoinAlumnoHorarioDetDto>> ObtenerHorario_dPorIdH(int? id);
        Task<int> DeleteHorario_dPorId(int id);
    }
}
