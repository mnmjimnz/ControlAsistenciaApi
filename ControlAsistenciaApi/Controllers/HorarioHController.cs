using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioHController : ControllerBase
    {
        private readonly IHorario_hUseCase _horario_hUseCase;
        public HorarioHController(IHorario_hUseCase a)
        {
            _horario_hUseCase = a;
        }
        [HttpGet("ObtenerHorario_hs")]
        public async Task<IActionResult> ObtenerHorario_hs(int PageSize, int PageNumber)
        {
            try
            {
                return Ok(await _horario_hUseCase.ObtenerHorario_hs(PageSize, PageNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("GuardarHorario_h")]
        public async Task<IActionResult> GuardarHorario_h([FromBody] Horario_hDto p)
        {
            try
            {
                return Ok(await _horario_hUseCase.GuardarHorario_h(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("EditarHorario_h")]
        public async Task<IActionResult> EditarHorario_h([FromBody] Horario_hDto p)
        {
            try
            {
                return Ok(await _horario_hUseCase.EditarHorario_h(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
