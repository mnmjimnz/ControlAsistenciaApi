using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Domain
{
    public class Registro_asistencia
    {
        public int? id { get; set; }
        public int? id_horario_d { get; set; }
        public bool estado { get; set; }
        public string? fecha { get; set; }
    }
}
