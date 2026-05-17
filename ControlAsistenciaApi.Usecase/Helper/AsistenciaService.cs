using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Infraestructure.Helper;
using ControlAsistenciaApi.Usecase.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace ControlAsistenciaApi.Usecase.Helper
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly JwtService _jwtService;
        private readonly IConfiguration _configuration;
        private readonly IRegistro_asistenciaUseCase _registro;
        private readonly IHubContext<AsistenciaHub> _hub;

        public AsistenciaService(JwtService jwtService, IConfiguration config, IRegistro_asistenciaUseCase registro, IHubContext<AsistenciaHub> hub)
        {
            _jwtService = jwtService;
            _configuration = config;
            _registro = registro;
            _hub = hub;
        }

        public object GenerarToken(
            int idHorarioH)
        {
            var _domain = _configuration["domain"]!;
            var token = _jwtService.GenerarTokenQR(
                idHorarioH);

            return new
            {
                token,
                url = $"{_domain}?t={token}&"
            };
        }

        public object ValidarToken(string token)
        {
            return _jwtService.ValidarTokenQR(token);
        }

        public async Task<ResponseAsistenciaConfirmDto> ConfirmarAsistencia(
        ConfirmarAsistenciaDto dto)
        {
            // 1. Validar JWT
            var token = _jwtService.ValidarTokenQR(dto.Token);
            if (!token.Valido)
            {
                return new ResponseAsistenciaConfirmDto
                {
                    Ok = false,
                    Mensaje = "QR expirado"
                };
            }

            // 2. Validar fingerprint
            bool fingerprintExiste =
                await _registro
                    .ExisteFingerprint(new Registro_asistenciaDto
                    {
                        fingerprint_sha256 = dto.Fingerprint,
                        id_horario_h = dto.id_horario_h,
                        user_agent = dto.user_agent
                    });

            if (fingerprintExiste)
            {
                return new ResponseAsistenciaConfirmDto
                {
                    Ok = false,
                    Mensaje =
                        "Este dispositivo ya confirmó asistencia"
                };
            }

            // 3. Validar alumno
            bool alumnoExiste =
                await _registro
                    .AlumnoYaConfirmo(new Registro_asistenciaDto { id_horario_h = dto.id_horario_h, id_horario_d = dto.id_horario_d, token_jti = dto.token_jti });

            if (alumnoExiste)
            {
                return new ResponseAsistenciaConfirmDto
                {
                    Ok = false,
                    Mensaje =
                        "Alumno ya confirmó asistencia"
                };
            }

            // 4. Guardar asistencia

            var result = await _registro.GuardarRegistro_asistencia(new Registro_asistenciaDto
            {
                estado = true,
                fecha = DateTime.Now.ToShortDateString(),
                id_horario_d = dto.id_horario_d,
                fingerprint_sha256 = dto.Fingerprint,
                id_horario_h = dto.id_horario_h,
                token_jti = dto.token_jti,
                user_agent = dto.user_agent
            });
            if (result != -1)
            {
                await _hub.Clients.All.SendAsync("AsistenciaActualizada");
                return new ResponseAsistenciaConfirmDto
                {
                    Ok = true,
                    Mensaje = "Asistencia registrada"
                };
            }
            return new ResponseAsistenciaConfirmDto
            {
                Ok = false,
                Mensaje = "No se pudo registrar la asistencia."
            };
        }
    }
}
