using System.ComponentModel.DataAnnotations;

namespace CursoIdioma.API.DTOs.Requests
{
    public class CriarMatriculaRequestDto
    {
        [Required(ErrorMessage = "Informe o ID da turma. ")]
        public Guid? TurmaId { get; set; }

        [Required(ErrorMessage = "Informe o ID do aluno. ")]
        public Guid? AlunoId { get; set; }
    }
}
