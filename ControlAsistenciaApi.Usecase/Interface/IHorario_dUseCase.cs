using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IHorario_dUseCase
    {
        Task<List<Horario_dDto>> ObtenerHorario_ds();
        Task<Horario_dDto> ObtenerHorario_dPorId(int? id);
        Task<int> GuardarHorario_d(Horario_dDto p);
        Task<int> EditarHorario_d(Horario_dDto p);
        Task<List<Horario_dDto>> ObtenerHorario_dPorIdH(int? id);
    }
}
