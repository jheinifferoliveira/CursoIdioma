using CursoIdioma.Domain.Enums;

namespace CursoIdioma.API.DTOs.Responses
{
    public class ExcluirTurmaResponseDto
    {
        public Guid? Id { get; set; }
        public string? Numero { get; set; }
        public string? AnoLetivo { get; set; }
        public Nivel? Nivel { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
    }
}
