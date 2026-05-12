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
    public class Horario_dRepository: IHorario_dRepository
    {
        private readonly IGenericRepository<Horario_d> _rep;
        private readonly IGenericRepository<JoinAlumnoHorarioDetDto> _repJoins;
        public Horario_dRepository(IGenericRepository<Horario_d> generic, IGenericRepository<JoinAlumnoHorarioDetDto> repJoins)
        {
            _rep = generic;
            _repJoins = repJoins;
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
        public async Task<IEnumerable<JoinAlumnoHorarioDetDto>> ObtenerHorario_dPorIdH(int? id)
        {
            try
            {
                //string sql = $"SELECT * FROM horario_d where idhorario_h = {id}";
                string sql = @$"select hd.id AS id_horariod, hd.idhorario_h, al.id AS id_alumno, al.nombre, al.apellido, al.carrera 
from horario_d hd
join alumno al on hd.idalumno  = al.id
where hd.idhorario_h = {id}
order by id_horariod desc;";
                return await _repJoins.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<JoinAlumnoHorarioDetDto>();
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
