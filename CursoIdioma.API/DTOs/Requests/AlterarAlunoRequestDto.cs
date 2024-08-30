using System.ComponentModel.DataAnnotations;

namespace CursoIdioma.API.DTOs.Requests
{
    public class AlterarAlunoRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe o ID do aluno.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do aluno.")]
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Informe um cpf válido com pontos e traço. Ex: 111.222.333-44")]
        [Required(ErrorMessage = "Por favor, informe o Cpf do aluno.")]
        public string? Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do aluno.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe o ID da turma. ")]
        public Guid? TurmaId { get; set; }
    }
}
