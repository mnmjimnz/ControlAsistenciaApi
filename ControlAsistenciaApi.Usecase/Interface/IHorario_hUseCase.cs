using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IHorario_hUseCase
    {
        Task<List<Horario_hDto>> ObtenerHorario_hs();
        Task<Horario_hDto> ObtenerHorario_hPorId(int? id);
        Task<int> GuardarHorario_h(Horario_hDto p);
        Task<int> EditarHorario_h(Horario_hDto p);
    }
}
