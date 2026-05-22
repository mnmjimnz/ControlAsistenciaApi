using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class Registro_asistenciaRepository : IRegistro_asistenciaRepository
    {
        private readonly IGenericRepository<Registro_asistencia> _rep;
        private readonly IGenericRepository<bool> _getExist;
        private readonly IGenericRepository<JoinAsistenciaAlumnosHorarioDet> _joinAsistencia;
        public Registro_asistenciaRepository(IGenericRepository<Registro_asistencia> generic, IGenericRepository<bool> getExist, IGenericRepository<JoinAsistenciaAlumnosHorarioDet> joinAsistencia)
        {
            _rep = generic;
            _getExist = getExist;
            _joinAsistencia = joinAsistencia;
        }
        public async Task<IEnumerable<Registro_asistencia>> ObtenerRegistro_asistencias()
        {
            try
            {
                string sql = "SELECT * FROM registro_asistencia";
                return await _rep.GetAllAsync(sql);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Registro_asistencia>();
            }
        }
        public async Task<IEnumerable<Registro_asistencia>> ObtenerRegistro_asistenciaPorId(int? id)
        {
            try
            {
                string sql = $"SELECT * FROM registro_asistencia where id = {id}";
                return await _rep.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Registro_asistencia>();
            }
        }
        public async Task<IEnumerable<JoinAsistenciaAlumnosHorarioDet>> ObtenerRegistro_asistenciaPorIdHorarioH(int? id, string fecha)
        {
            try
            {
                string sql = @$"SELECT 
    hd.id AS id_horariod,
    hd.idhorario_h, 
    al.id AS id_alumno,
    al.nombre,
    al.apellido,
    al.carrera,
    rg.estado,
    rg.fecha

FROM horario_d hd

INNER JOIN alumno al 
    ON hd.idalumno = al.id

LEFT JOIN registro_asistencia rg 
    ON rg.id_horario_d = hd.id
    AND rg.id_horario_h = hd.idhorario_h

WHERE hd.idhorario_h = @id
AND rg.estado = true
AND rg.fecha = @fecha
ORDER BY hd.id DESC;";
                return await _joinAsistencia.GetAllAsync(sql, new {id, fecha});
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<JoinAsistenciaAlumnosHorarioDet>();
            }
        }
        public async Task<int> GuardarRegistro_asistencia(Registro_asistencia p)
        {
            try
            {
                string sql = "INSERT INTO registro_asistencia(id_horario_d, id_horario_h, estado, fecha, fingerprint_sha256, user_agent, token_jti) VALUES(@id_horario_d, @id_horario_h, @estado, @fecha, @fingerprint_sha256, @user_agent, @token_jti) RETURNING id;";
                var id = await _rep.InsertScalarAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarRegistro_asistencia(Registro_asistencia p)
        {
            try
            {
                string sql = "UPDATE registro_asistencia SET id_horario_d = @id_horario_d, estado = @estado, fecha = @fecha WHERE id = @id";
                var id = await _rep.UpdateAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<bool> ExisteFingerprint(Registro_asistencia data)
        {
            try
            {
                string sql = @$"SELECT EXISTS
(
    SELECT 1
    FROM registro_asistencia
    WHERE id_horario_h = @id_horario_h

    AND fingerprint_sha256 = @fingerprint_sha256

    AND user_agent = @user_agent
AND token_jti = @token_jti
);";
                var r = await _getExist.GetAllAsync(sql, new { data.id_horario_h, data.fingerprint_sha256, data.user_agent, data.token_jti });
                return r.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AlumnoYaConfirmo(Registro_asistencia data)
        {
            try
            {
                string sql = @$"SELECT EXISTS
(
    SELECT 1
    FROM registro_asistencia
    WHERE id_horario_h = {data.id_horario_h}
    AND id_horario_d = {data.id_horario_d}
    AND token_jti = {data.token_jti}
);";
                var r = await _getExist.GetAllAsync(sql, data);
                return r.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
