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
    public class Horario_hUseCase: IHorario_hUseCase
    {
        private readonly IHorario_hRepository _repoHorario_h;
        private readonly IMapper _mapper;
        public Horario_hUseCase(IHorario_hRepository repo, IMapper map)
        {
            _repoHorario_h = repo;
            _mapper = map;
        }

        public async Task<List<Horario_hDto>> ObtenerHorario_hs(int PageSize, int PageNumber)
        {
            try
            {
                var r = await _repoHorario_h.ObtenerHorario_h(PageSize, PageNumber);
                return _mapper.Map<List<Horario_hDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<Horario_hDto>();
            }
        }
        public async Task<List<Horario_hDto>> ObtenerHorario_hPorIdAula(int idAula, int PageSize, int PageNumber)
        {
            try
            {
                var r = await _repoHorario_h.ObtenerHorario_hPorIdAula(idAula ,PageSize, PageNumber);
                return _mapper.Map<List<Horario_hDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<Horario_hDto>();
            }
        }
        public async Task<Horario_hDto> ObtenerHorario_hPorId(int? id)
        {
            try
            {
                var r = await _repoHorario_h.ObtenerHorario_hPorId(id);
                return _mapper.Map<Horario_hDto>(r.SingleOrDefault());
            }
            catch (Exception ex)
            {
                return new Horario_hDto();
            }
        }
        public async Task<int> GuardarHorario_h(Horario_hDto p)
        {
            try
            {
                var o = _mapper.Map<Horario_h>(p);
                return await _repoHorario_h.GuardarHorario_h(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarHorario_h(Horario_hDto p)
        {
            try
            {
                var o = _mapper.Map<Horario_h>(p);
                return await _repoHorario_h.EditarHorario_h(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
