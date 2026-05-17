using AutoMapper;
using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Infraestructure;
using ControlAsistenciaApi.Infraestructure.Interface;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaUseCase _materiaUseCase;
        public MateriaController(IMateriaUseCase a)
        {
            _materiaUseCase = a;
        }
        [HttpGet("ObtenerMaterias")]
        public async Task<IActionResult> ObtenerMaterias(int PageSize, int PageNumber)
        {
            try
            {
                return Ok(await _materiaUseCase.ObtenerMaterias(PageSize, PageNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ObtenerMateriasPorId")]
        public async Task<IActionResult> ObtenerMateriasPorId(int id)
        {
            try
            {
                return Ok(await _materiaUseCase.ObtenerMateriaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("GuardarMateria")]
        public async Task<IActionResult> GuardarMateria([FromBody] MateriaDto p)
        {
            try
            {
                return Ok(await _materiaUseCase.GuardarMateria(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("EditarMateria")]
        public async Task<IActionResult> EditarMateria([FromBody] MateriaDto p)
        {
            try
            {
                return Ok(await _materiaUseCase.EditarMateria(p));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
