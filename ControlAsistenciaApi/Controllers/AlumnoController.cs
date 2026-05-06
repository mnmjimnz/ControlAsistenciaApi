using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoUseCase _alumnoU;
        public AlumnoController(IAlumnoUseCase a)
        {
            _alumnoU = a;
        }
        [HttpGet("ObtenerAlumnos")]
        public async Task<IActionResult> ObtenerAlumnos()
        {
            try
            {
                return Ok(await _alumnoU.ObtenerAlumnos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("GuardarAlumno")]
        public async Task<IActionResult> GuardarAlumno([FromBody] AlumnoDto p)
        {
            try
            {
                return Ok(await _alumnoU.GuardarAlumno(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("EditarAlumno")]
        public async Task<IActionResult> EditarAlumno([FromBody] AlumnoDto p)
        {
            try
            {
                return Ok(await _alumnoU.EditarAlumno(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
