using CursoIdioma.API.DTOs.Requests;
using CursoIdioma.API.DTOs.Responses;
using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoIdioma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarAlunoResponseDto), 201)]
        public IActionResult Cadastro(CriarAlunoRequestDto dto)
        {
            try
            {
                var aluno = new Aluno() {
                    Nome = dto.Nome,
                    Cpf = dto.Cpf,
                    Email = dto.Email,
                    Id= Guid.NewGuid(),
                };

                _alunoService.Criar(aluno, dto.TurmaId.Value);                

                var response = new CriarAlunoResponseDto() {
                    Id=aluno.Id,
                    Nome= aluno.Nome,
                    Cpf= aluno.Cpf,
                    Email= aluno.Email
                };

                return StatusCode(201,response);
            }
            catch(ApplicationException e) 
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(AlterarAlunoResponseDto),200)]
        public IActionResult Alteracao(AlterarAlunoRequestDto dto)
        {
            try
            {
                var aluno = new Aluno()
                {
                    Id=(Guid)dto.Id,
                    Nome= dto.Nome,
                    Cpf= dto.Cpf,
                    Email= dto.Email             
                };

                _alunoService.Alterar(aluno);

                var response = new AlterarAlunoResponseDto()
                {
                    Id=aluno.Id,
                    Nome=aluno.Nome,
                    Cpf= aluno.Cpf,
                    Email= aluno.Email,
                    DataHoraAlteracao=DateTime.Now
                };


                return StatusCode(200,response);
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

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarAlunosResponseDto>),200)]
        public IActionResult Consulta()
        {
            try
            {
                var response = _alunoService.ConsultarTodos();

                return StatusCode(200,response);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirAlunoResponseDto),200)]
        public IActionResult Exclusao(Guid id)
        {
            try
            {   
                var aluno = _alunoService.ConsultarUmAluno(id);
                _alunoService.Excluir(id);

                var response = new ExcluirAlunoResponseDto()
                {
                    Id= aluno.Id,
                    Nome= aluno.Nome,
                    Cpf= aluno.Cpf,
                    Email= aluno.Email,
                    DataHoraExclusao=DateTime.Now
                };

                return StatusCode(200,response);
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
