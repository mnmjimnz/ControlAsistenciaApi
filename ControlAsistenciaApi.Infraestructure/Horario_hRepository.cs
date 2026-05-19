using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class Horario_hRepository: IHorario_hRepository
    {
        private readonly IGenericRepository<Horario_h> _rep;
        public Horario_hRepository(IGenericRepository<Horario_h> generic)
        {
            _rep = generic;
        }
        public async Task<IEnumerable<Horario_h>> ObtenerHorario_h(int PageSize, int PageNumber)
        {
            try
            {
                string sql = $@"SELECT * FROM horario_h
                                ORDER BY id
                                OFFSET {(PageNumber - 1) * PageSize} ROWS 
                                FETCH NEXT {PageSize} ROWS ONLY;";
                return await _rep.GetAllAsync(sql);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Horario_h>();
            }
        }
        public async Task<IEnumerable<Horario_h>> ObtenerHorario_hPorIdAula(int idAula, int PageSize, int PageNumber)
        {
            try
            {
                string sql = $@"SELECT * FROM horario_h WHERE idaula = {idAula}
                                ORDER BY id
                                OFFSET {(PageNumber - 1) * PageSize} ROWS 
                                FETCH NEXT {PageSize} ROWS ONLY;";
                return await _rep.GetAllAsync(sql, idAula);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Horario_h>();
            }
        }
        public async Task<IEnumerable<Horario_h>> ObtenerHorario_hPorId(int? id)
        {
            try
            {
                string sql = $"SELECT * FROM horario_h where id = {id}";
                return await _rep.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Horario_h>();
            }
        }
        public async Task<int> GuardarHorario_h(Horario_h p)
        {
            try
            {
                string sql = "INSERT INTO horario_h(idaula, idmateria, hora_inicio, hora_fin, fecha, catedratico, grupo) VALUES(@idaula, @idmateria, @hora_inicio, @hora_fin, @fecha, @catedratico, @grupo) RETURNING id;";
                var id = await _rep.InsertScalarAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarHorario_h(Horario_h p)
        {
            try
            {
                string sql = "UPDATE horario_h SET idaula = @idaula, idmateria = @idmateria, hora_inicio = @hora_inicio, hora_fin = @hora_fin, fecha = @fecha, catedratico = @catedratico, grupo = @grupo WHERE id = @id";
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
