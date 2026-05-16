using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure.Interface
{
    public interface IRegistro_asistenciaRepository
    {
        Task<IEnumerable<Registro_asistencia>> ObtenerRegistro_asistencias();
        Task<IEnumerable<Registro_asistencia>> ObtenerRegistro_asistenciaPorId(int? id);
        Task<int> GuardarRegistro_asistencia(Registro_asistencia p);
        Task<int> EditarRegistro_asistencia(Registro_asistencia p);
        Task<bool> ExisteFingerprint(Registro_asistencia data);
        Task<bool> AlumnoYaConfirmo(Registro_asistencia data);
        Task<IEnumerable<JoinAsistenciaAlumnosHorarioDet>> ObtenerRegistro_asistenciaPorIdHorarioH(int? id);
    }
}
