using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Dtos
{
    public class Registro_asistenciaDto
    {
        public int? id { get; set; }
        public int? id_horario { get; set; }
        public bool estado { get; set; }
        public DateTime? fecha { get; set; }
    }
}
