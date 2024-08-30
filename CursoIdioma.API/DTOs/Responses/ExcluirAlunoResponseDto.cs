namespace CursoIdioma.API.DTOs.Responses
{
    public class ExcluirAlunoResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public Guid TurmaId { get; set; }
        public DateTime DataHoraExclusao { get; set; }
    }
}
