using AutoMapper;
using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Infraestructure.Interface;
using ControlAsistenciaApi.Usecase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Usecase
{
    public class MateriaUseCase: IMateriaUseCase
    {
        private readonly IMateriaRepository _repoMateria;
        private readonly IMapper _mapper;
        public MateriaUseCase(IMateriaRepository repo, IMapper map)
        {
            _repoMateria = repo;
            _mapper = map;
        }

        public async Task<List<MateriaDto>> ObtenerMaterias()
        {
            try
            {
                var r = await _repoMateria.ObtenerMaterias();
                return _mapper.Map<List<MateriaDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<MateriaDto>();
            }
        }
        public async Task<MateriaDto> ObtenerMateriaPorId(int? id)
        {
            try
            {
                var r = await _repoMateria.ObtenerMateriaPorId(id);
                return _mapper.Map<MateriaDto>(r);
            }
            catch (Exception ex)
            {
                return new MateriaDto();
            }
        }
        public async Task<int> GuardarMateria(MateriaDto p)
        {
            try
            {
                var o = _mapper.Map<Materia>(p);
                return await _repoMateria.GuardarMateria(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarMateria(MateriaDto p)
        {
            try
            {
                var o = _mapper.Map<Materia>(p);
                return await _repoMateria.EditarMateria(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
