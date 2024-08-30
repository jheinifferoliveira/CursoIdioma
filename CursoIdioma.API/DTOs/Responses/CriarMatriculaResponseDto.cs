using System.ComponentModel.DataAnnotations;

namespace CursoIdioma.API.DTOs.Responses
{
    public class CriarMatriculaResponseDto
    {
        public Guid? TurmaId { get; set; }
        public Guid? AlunoId { get; set; }
    }
}
