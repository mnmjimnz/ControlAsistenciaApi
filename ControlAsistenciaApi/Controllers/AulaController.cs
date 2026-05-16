using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IAulaUseCase _aulaUseCase;
        public AulaController(IAulaUseCase a)
        {
            _aulaUseCase = a;
        }
        [HttpGet("ObtenerAulas")]
        public async Task<IActionResult> ObtenerAulas()
        {
            try
            {
                return Ok(await _aulaUseCase.ObtenerAulas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ObtenerAulasPorId")]
        public async Task<IActionResult> ObtenerAulasPorId(int id)
        {
            try
            {
                return Ok(await _aulaUseCase.ObtenerAulaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("GuardarAula")]
        public async Task<IActionResult> GuardarAula([FromBody] AulaDto p)
        {
            try
            {
                return Ok(await _aulaUseCase.GuardarAula(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("EditarAula")]
        public async Task<IActionResult> EditarAula([FromBody] AulaDto p)
        {
            try
            {
                return Ok(await _aulaUseCase.EditarAula(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
