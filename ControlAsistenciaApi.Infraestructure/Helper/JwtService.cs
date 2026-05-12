using ControlAsistenciaApi.Core.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlAsistenciaApi.Infraestructure.Helper
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region generarToken
        public string GenerarTokenQR(
            int idHorarioH)
        {
            var key = _configuration["Jwt:Key"]!;
            var issuer = _configuration["Jwt:Issuer"]!;
            var audience = _configuration["Jwt:Audience"]!;

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim("idHorarioH", idHorarioH.ToString()),
            new Claim("tipo", "QR_ASISTENCIA")
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        } 
        #endregion
        #region validarToken
        public ResultadoTokenDto ValidarTokenQR(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!);

            try
            {
                tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey =
                            new SymmetricSecurityKey(key),

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,

                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],

                        ClockSkew = TimeSpan.Zero
                    },
                    out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var idHorarioH = int.Parse(
                    jwtToken.Claims
                        .First(x => x.Type == "idHorarioH")
                        .Value);

                return new ResultadoTokenDto
                {
                    Valido = true,
                    IdHorarioH = idHorarioH
                };
            }
            catch
            {
                return new ResultadoTokenDto
                {
                    Valido = false,
                    Mensaje = "Token inválido o expirado"
                };
            }
        }
        #endregion
    }
}
