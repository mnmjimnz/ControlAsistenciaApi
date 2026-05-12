using System.Security.Cryptography;

namespace ControlAsistenciaApi.Usecase.Helper
{
    public class WebAuthnService
    {
        public string GenerarChallenge()
        {
            // 32 bytes aleatorios seguros
            byte[] challengeBytes = RandomNumberGenerator.GetBytes(32);

            // Convertir a Base64
            return Convert.ToBase64String(challengeBytes);
        }
    }
}
