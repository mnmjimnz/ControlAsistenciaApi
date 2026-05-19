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
        Task<List<Horario_hDto>> ObtenerHorario_hs(int PageSize, int PageNumber);
        Task<Horario_hDto> ObtenerHorario_hPorId(int? id);
        Task<int> GuardarHorario_h(Horario_hDto p);
        Task<int> EditarHorario_h(Horario_hDto p);
        Task<List<Horario_hDto>> ObtenerHorario_hPorIdAula(int idAula, int PageSize, int PageNumber);
        Task<List<Horario_hDto>> ObtenerHorario_hPorDiaYAnio(string dia, string anio, int PageSize, int PageNumber);
    }
}
