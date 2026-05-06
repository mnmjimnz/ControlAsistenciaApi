using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Dtos
{
    public class AlumnoDto
    {
        public int? id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string carrera { get; set; } = string.Empty;
    }
}
