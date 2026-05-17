using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class AulaRepository: IAulaRepository
    {
        private readonly IGenericRepository<Aula> _rep;
        public AulaRepository(IGenericRepository<Aula> generic)
        {
            _rep = generic;
        }
        public async Task<IEnumerable<Aula>> ObtenerAulas(int PageSize, int PageNumber)
        {
            try
            {
                string sql = $@"SELECT * FROM aula
                                ORDER BY id
                                OFFSET {(PageNumber - 1) * PageSize} ROWS 
                                FETCH NEXT {PageSize} ROWS ONLY;";
                return await _rep.GetAllAsync(sql);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Aula>();
            }
        }
        public async Task<IEnumerable<Aula>> ObtenerAulaPorId(int? id)
        {
            try
            {
                string sql = $"SELECT * FROM aula where id = {id}";
                return await _rep.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Aula>();
            }
        }
        public async Task<int> GuardarAula(Aula p)
        {
            try
            {
                string sql = "INSERT INTO aula(codigo) VALUES(@codigo) RETURNING id;";
                var id = await _rep.InsertScalarAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarAula(Aula p)
        {
            try
            {
                string sql = "UPDATE aula SET codigo = @codigo WHERE id = @id";
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
