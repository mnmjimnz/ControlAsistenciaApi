namespace ControlAsistenciaApi.Core.Dtos
{
    public class ResultadoTokenDto
    {
        public bool Valido { get; set; }

        public string? Mensaje { get; set; }

        public int IdHorarioH { get; set; }
    }
}
