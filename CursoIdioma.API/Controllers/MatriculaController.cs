using CursoIdioma.API.DTOs.Requests;
using CursoIdioma.API.DTOs.Responses;
using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Services;
using CursoIdioma.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoIdioma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarMatriculaRequestDto), 201)]
        public IActionResult Cadastro(CriarMatriculaResponseDto dto)
        {
            try
            {
                var matricula = new Matricula()
                {
                    TurmaId = dto.TurmaId.Value,
                    AlunoId = dto.AlunoId.Value
                };

                _matriculaService.Criar(matricula);

                var response = new CriarMatriculaResponseDto()
                {
                    TurmaId = matricula.TurmaId,
                    AlunoId = matricula.AlunoId
                };

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{turmaId}/{alunoId}")]
        [ProducesResponseType(typeof(ExcluirMatriculaResponseDto), 200)]
        public IActionResult Exclusao(Guid turmaId, Guid alunoId)
        {
            try
            {
                _matriculaService.Excluir(turmaId, alunoId);

                var response = new ExcluirMatriculaResponseDto()
                {
                    TurmaId = turmaId,
                    AlunoId = alunoId
                };

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
