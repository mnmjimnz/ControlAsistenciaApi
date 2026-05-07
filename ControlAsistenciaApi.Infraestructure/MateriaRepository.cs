using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class MateriaRepository: IMateriaRepository
    {
        private readonly IGenericRepository<Materia> _rep;
        public MateriaRepository(IGenericRepository<Materia> generic)
        {
            _rep = generic;
        }
        public async Task<IEnumerable<Materia>> ObtenerMaterias()
        {
            try
            {
                string sql = "SELECT * FROM materia";
                return await _rep.GetAllAsync(sql);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Materia>();
            }
        }
        public async Task<IEnumerable<Materia>> ObtenerMateriaPorId(int? id)
        {
            try
            {
                string sql = $"SELECT * FROM materia where id = {id}";
                return await _rep.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Materia>();
            }
        }
        public async Task<int> GuardarMateria(Materia p)
        {
            try
            {
                string sql = "INSERT INTO materia(nombre) VALUES(@nombre) RETURNING id;";
                var id = await _rep.InsertScalarAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarMateria(Materia p)
        {
            try
            {
                string sql = "UPDATE materia SET nombre = @nombre WHERE id = @id";
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
