using CursoIdioma.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CursoIdioma.API.DTOs.Responses
{
    public class CriarTurmaResponseDto
    {
        public Guid Id { get; set; }
        public string? Numero { get; set; }
        public string? AnoLetivo { get; set; }
        public Nivel? Nivel { get; set; }
    }
}
