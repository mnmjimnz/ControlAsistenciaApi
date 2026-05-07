using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class Registro_asistenciaRepository: IRegistro_asistenciaRepository
    {
        private readonly IGenericRepository<Registro_asistencia> _rep;
        public Registro_asistenciaRepository(IGenericRepository<Registro_asistencia> generic)
        {
            _rep = generic;
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
        public async Task<int> GuardarRegistro_asistencia(Registro_asistencia p)
        {
            try
            {
                string sql = "INSERT INTO registro_asistencia(id_horario_d, estado, fecha) VALUES(@id_horario_d, @estado, @fecha) RETURNING id;";
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
    }
}
