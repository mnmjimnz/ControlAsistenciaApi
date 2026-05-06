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
        public DateTime? hora_inicio { get; set; }
        public DateTime? hora_fin { get; set; }
        public DateTime? fecha { get; set; }
        public string catedratico { get; set; } = string.Empty;
    }
}
