using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase.Interface
{
    public interface IRegistro_asistenciaUseCase
    {
        Task<List<Registro_asistenciaDto>> ObtenerRegistro_asistencias();
        Task<Registro_asistenciaDto> ObtenerRegistro_asistenciaPorId(int? id);
        Task<List<JoinAsistenciaAlumnosHorarioDet>> ObtenerRegistro_asistenciaPorIdHorarioH(int? id, string fecha);
        Task<int> GuardarRegistro_asistencia(Registro_asistenciaDto p);
        Task<int> EditarRegistro_asistencia(Registro_asistenciaDto p);
        Task<bool> ExisteFingerprint(Registro_asistenciaDto p);
        Task<bool> AlumnoYaConfirmo(Registro_asistenciaDto p);
    }
}
