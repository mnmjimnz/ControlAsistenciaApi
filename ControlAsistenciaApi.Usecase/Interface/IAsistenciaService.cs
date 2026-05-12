using ControlAsistenciaApi.Core.Dtos;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IAsistenciaService
    {
        object GenerarToken(int idHorarioH);
        object ValidarToken(string token);
        Task<ResponseAsistenciaConfirmDto> ConfirmarAsistencia(ConfirmarAsistenciaDto dto);
    }
}
