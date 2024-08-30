using CursoIdioma.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CursoIdioma.API.DTOs.Requests
{
    public class CriarTurmaRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe o número da turma.")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o ano letivo da turma.")]
        public string? AnoLetivo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nível da turma.")]
        public Nivel? Nivel { get; set; }
    }
}
