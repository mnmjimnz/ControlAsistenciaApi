using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Dtos
{
    public class ConfirmarAsistenciaDto : Registro_asistenciaDto
    {
        public string Token { get; set; } = "";
        public int AlumnoId { get; set; }
        public string Fingerprint { get; set; } = "";
        public int idhorariod { get; set; }
    }
}
