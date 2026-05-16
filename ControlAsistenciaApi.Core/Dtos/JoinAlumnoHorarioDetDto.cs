using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Dtos
{
    public class JoinAlumnoHorarioDetDto
    {
        public int? id_horariod { get; set; }
        public int? idhorario_h { get; set; }
        public int? id_alumno { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string carrera { get; set; } = string.Empty;
    }
    public class JoinAsistenciaAlumnosHorarioDet:JoinAlumnoHorarioDetDto
    {
        public bool estado { get; set; }
        public string fecha { get; set; } = string.Empty;
    }
}
