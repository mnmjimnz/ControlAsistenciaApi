using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioDController : ControllerBase
    {
        private readonly IHorario_dUseCase _horario_dUseCase;
        public HorarioDController(IHorario_dUseCase a)
        {
            _horario_dUseCase = a;
        }
        [HttpGet("ObtenerHorario_ds")]
        public async Task<IActionResult> ObtenerHorario_ds()
        {
            try
            {
                return Ok(await _horario_dUseCase.ObtenerHorario_ds());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ObtenerHorarioPorIdH")]
        public async Task<IActionResult> ObtenerHorarioPorIdH(int id)
        {
            try
            {
                return Ok(await _horario_dUseCase.ObtenerHorario_dPorIdH(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("GuardarHorario_d")]
        public async Task<IActionResult> GuardarHorario_d([FromBody] Horario_dDto p)
        {
            try
            {
                return Ok(await _horario_dUseCase.GuardarHorario_d(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("EditarHorario_d")]
        public async Task<IActionResult> EditarHorario_d([FromBody] Horario_dDto p)
        {
            try
            {
                return Ok(await _horario_dUseCase.EditarHorario_d(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("DeleteHorario_dPorId")]
        public async Task<IActionResult> DeleteHorario_dPorId(int id)
        {
            try
            {
                return Ok(await _horario_dUseCase.DeleteHorario_dPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
