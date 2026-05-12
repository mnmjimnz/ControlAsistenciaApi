using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsistenciaApi.Core.Dtos
{
    public class ResponseAsistenciaConfirmDto
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
