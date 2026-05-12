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
    public class Registro_asistenciaUseCase: IRegistro_asistenciaUseCase
    {
        private readonly IRegistro_asistenciaRepository _repoRegistro_asistencia;
        private readonly IMapper _mapper;
        public Registro_asistenciaUseCase(IRegistro_asistenciaRepository repo, IMapper map)
        {
            _repoRegistro_asistencia = repo;
            _mapper = map;
        }

        public async Task<List<Registro_asistenciaDto>> ObtenerRegistro_asistencias()
        {
            try
            {
                var r = await _repoRegistro_asistencia.ObtenerRegistro_asistencias();
                return _mapper.Map<List<Registro_asistenciaDto>>(r);
            }
            catch (Exception ex)
            {
                return new List<Registro_asistenciaDto>();
            }
        }
        public async Task<Registro_asistenciaDto> ObtenerRegistro_asistenciaPorId(int? id)
        {
            try
            {
                var r = await _repoRegistro_asistencia.ObtenerRegistro_asistenciaPorId(id);
                return _mapper.Map<Registro_asistenciaDto>(r);
            }
            catch (Exception ex)
            {
                return new Registro_asistenciaDto();
            }
        }
        public async Task<int> GuardarRegistro_asistencia(Registro_asistenciaDto p)
        {
            try
            {
                var o = _mapper.Map<Registro_asistencia>(p);
                return await _repoRegistro_asistencia.GuardarRegistro_asistencia(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> EditarRegistro_asistencia(Registro_asistenciaDto p)
        {
            try
            {
                var o = _mapper.Map<Registro_asistencia>(p);
                return await _repoRegistro_asistencia.EditarRegistro_asistencia(o);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<bool> ExisteFingerprint(Registro_asistenciaDto p)
        {
            try
            {
                var o = _mapper.Map<Registro_asistencia>(p);
                return await _repoRegistro_asistencia.ExisteFingerprint(o);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AlumnoYaConfirmo(Registro_asistenciaDto p)
        {
            try
            {
                var o = _mapper.Map<Registro_asistencia>(p);
                return await _repoRegistro_asistencia.AlumnoYaConfirmo(o);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
