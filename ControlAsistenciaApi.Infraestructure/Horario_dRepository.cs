using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class Horario_dRepository: IHorario_dRepository
    {
        private readonly IGenericRepository<Horario_d> _rep;
        public Horario_dRepository(IGenericRepository<Horario_d> generic)
        {
            _rep = generic;
        }
        public async Task<IEnumerable<Horario_d>> ObtenerHorario_d()
        {
            try
            {
                string sql = "SELECT * FROM horario_d";
                return await _rep.GetAllAsync(sql);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Horario_d>();
            }
        }
        public async Task<IEnumerable<Horario_d>> ObtenerHorario_dPorId(int? id)
        {
            try
            {
                string sql = $"SELECT * FROM horario_d where id = {id}";
                return await _rep.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Horario_d>();
            }
        }
        public async Task<int> GuardarHorario_d(Horario_d p)
        {
            try
            {
                string sql = "INSERT INTO horario_d(idalumno, idhorario_h) VALUES(@idalumno, @idhorario_h) RETURNING id;";
                var id = await _rep.InsertScalarAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarHorario_d(Horario_d p)
        {
            try
            {
                string sql = "UPDATE horario_d SET idalumno = @idalumno, idhorario_h = @idhorario_h WHERE id = @id";
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
