using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registro_asistenciaController : ControllerBase
    {
        private readonly IRegistro_asistenciaUseCase _registro_asistenciaUseCase;
        public Registro_asistenciaController(IRegistro_asistenciaUseCase a)
        {
            _registro_asistenciaUseCase = a;
        }
        [HttpGet("ObtenerRegistro_asistencias")]
        public async Task<IActionResult> ObtenerRegistro_asistencias()
        {
            try
            {
                return Ok(await _registro_asistenciaUseCase.ObtenerRegistro_asistencias());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("GuardarRegistro_asistencia")]
        public async Task<IActionResult> GuardarRegistro_asistencia([FromBody] Registro_asistenciaDto p)
        {
            try
            {
                return Ok(await _registro_asistenciaUseCase.GuardarRegistro_asistencia(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("EditarRegistro_asistencia")]
        public async Task<IActionResult> EditarRegistro_asistencia([FromBody] Registro_asistenciaDto p)
        {
            try
            {
                return Ok(await _registro_asistenciaUseCase.EditarRegistro_asistencia(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
