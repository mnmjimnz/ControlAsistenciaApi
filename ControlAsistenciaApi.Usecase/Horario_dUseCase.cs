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
    public class Horario_dUseCase: IHorario_dUseCase
    {
        private readonly IHorario_dRepository _repoHorario_d;
        private readonly IMapper _mapper;
        public Horario_dUseCase(IHorario_dRepository repo, IMapper map)
        {
            _repoHorario_d = repo;
            _mapper = map;
        }

        public async Task<List<Horario_dDto>> ObtenerHorario_ds()
        {
            try
            {
                var r = await _repoHorario_d.ObtenerHorario_d();
                return _mapper.Map<List<Horario_dDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<Horario_dDto>();
            }
        }
        public async Task<Horario_dDto> ObtenerHorario_dPorId(int? id)
        {
            try
            {
                var r = await _repoHorario_d.ObtenerHorario_dPorId(id);
                return _mapper.Map<Horario_dDto>(r);
            }
            catch (Exception ex)
            {
                return new Horario_dDto();
            }
        }
        public async Task<List<Horario_dDto>> ObtenerHorario_dPorIdH(int? id)
        {
            try
            {
                var r = await _repoHorario_d.ObtenerHorario_dPorIdH(id);
                return _mapper.Map<List<Horario_dDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<Horario_dDto>();
            }
        }
        public async Task<int> GuardarHorario_d(Horario_dDto p)
        {
            try
            {
                var o = _mapper.Map<Horario_d>(p);
                return await _repoHorario_d.GuardarHorario_d(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarHorario_d(Horario_dDto p)
        {
            try
            {
                var o = _mapper.Map<Horario_d>(p);
                return await _repoHorario_d.EditarHorario_d(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
