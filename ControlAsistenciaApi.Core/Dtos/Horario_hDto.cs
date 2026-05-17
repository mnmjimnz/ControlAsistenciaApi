using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Dtos
{
    public class Horario_hDto
    {
        public int? id { get; set; }
        public int? idaula { get; set; }
        public int? idmateria { get; set; }
        public string? hora_inicio { get; set; }
        public string? hora_fin { get; set; }
        public string fecha { get; set; } = string.Empty;
        public string catedratico { get; set; } = string.Empty;
        public string grupo { get; set; } = string.Empty;
    }
}
