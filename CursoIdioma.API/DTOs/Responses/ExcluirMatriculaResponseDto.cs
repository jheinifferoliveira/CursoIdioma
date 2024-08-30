using System.ComponentModel.DataAnnotations;

namespace CursoIdioma.API.DTOs.Responses
{
    public class ExcluirMatriculaResponseDto
    {
        public Guid? TurmaId { get; set; }
        public Guid? AlunoId { get; set; }
    }
}
