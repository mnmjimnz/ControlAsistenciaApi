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
        Task<IEnumerable<Horario_h>> ObtenerHorario_h(int PageSize, int PageNumber);
        Task<IEnumerable<Horario_h>> ObtenerHorario_hPorId(int? id);
        Task<int> GuardarHorario_h(Horario_h p);
        Task<int> EditarHorario_h(Horario_h p);
        Task<IEnumerable<Horario_h>> ObtenerHorario_hPorIdAula(int idAula, int PageSize, int PageNumber);
        Task<IEnumerable<Horario_h>> ObtenerHorario_hPorDiaYAnio(string dia, string anio, int PageSize, int PageNumber);
        Task<IEnumerable<Horario_h>> ObtenerHorario_hPorDiaAnioAulaCicloMateria(string dia, string anio, int? aula, int? materia, string ciclo, int PageSize, int PageNumber);
    }
}
