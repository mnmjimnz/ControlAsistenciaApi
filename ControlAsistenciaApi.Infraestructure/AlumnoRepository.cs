using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Infraestructure
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly IGenericRepository<Alumno> _rep;
        public AlumnoRepository(IGenericRepository<Alumno> generic)
        {
            _rep = generic;
        }
        public async Task<IEnumerable<Alumno>> ObtenerAlumnos()
        {
            try
            {
                string sql = "SELECT * FROM public.alumno";
                var r = await _rep.GetAllAsync(sql);
                return r;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Alumno>();
            }
        }
        public async Task<IEnumerable<Alumno>> ObtenerAlumnoPorId(int? id)
        {
            try
            {
                string sql = $"SELECT * FROM alumno where id = {id}";
                return await _rep.GetAllAsync(sql, id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Alumno>();
            }
        }
        public async Task<int> GuardarAlumno(Alumno p)
        {
            try
            {
                string sql = "INSERT INTO public.alumno(nombre, apellido, carrera) VALUES(@nombre, @apellido, @carrera) RETURNING id;";
                var id = await _rep.InsertScalarAsync(sql, p);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarAlumno(Alumno p)
        {
            try
            {
                string sql = "UPDATE public.alumno SET nombre = @nombre, apellido = @apellido, carrera = @carrera WHERE id = @id";
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
