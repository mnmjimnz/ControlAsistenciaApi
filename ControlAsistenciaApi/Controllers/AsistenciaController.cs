using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Usecase.Helper;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;
        public AsistenciaController(IAsistenciaService service)
        {
            _asistenciaService = service;
        }
        [HttpPost("generar-token")]
        public IActionResult GenerarQR([FromBody] int idHorarioH)
        {
            var resultado = _asistenciaService
                .GenerarToken(idHorarioH);

            return Ok(resultado);
        }
        [HttpGet("validar")]
        public IActionResult ValidarQR([FromQuery] string t)
        {
            var resultado = _asistenciaService
                .ValidarToken(t);

            return Ok(resultado);
        }
        [HttpPost("challenge")]
        public IActionResult ObtenerChallenge([FromServices] WebAuthnService webAuthnService)
        {
            var challenge = webAuthnService.GenerarChallenge();

            return Ok(new
            {
                challenge
            });
        }
        [HttpPost("confirmar")]
        public async Task<IActionResult> Confirmar([FromBody] ConfirmarAsistenciaDto dto)
        {
            var resultado =
                await _asistenciaService
                    .ConfirmarAsistencia(dto);

            if (!resultado.Ok)
            {
                return BadRequest(resultado);
            }

            return Ok(resultado);
        }
    }
}
