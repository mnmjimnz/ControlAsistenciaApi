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
    public class AulaUseCase: IAulaUseCase
    {
        private readonly IAulaRepository _repoAula;
        private readonly IMapper _mapper;
        public AulaUseCase(IAulaRepository repo, IMapper map)
        {
            _repoAula = repo;
            _mapper = map;
        }

        public async Task<List<AulaDto>> ObtenerAulas()
        {
            try
            {
                var r = await _repoAula.ObtenerAulas();
                return _mapper.Map<List<AulaDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<AulaDto>();
            }
        }
        public async Task<AulaDto> ObtenerAulaPorId(int? id)
        {
            try
            {
                var r = await _repoAula.ObtenerAulaPorId(id);
                return _mapper.Map<AulaDto>(r);
            }
            catch (Exception ex)
            {
                return new AulaDto();
            }
        }
        public async Task<int> GuardarAula(AulaDto p)
        {
            try
            {
                var o = _mapper.Map<Aula>(p);
                return await _repoAula.GuardarAula(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarAula(AulaDto p)
        {
            try
            {
                var o = _mapper.Map<Aula>(p);
                return await _repoAula.EditarAula(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
