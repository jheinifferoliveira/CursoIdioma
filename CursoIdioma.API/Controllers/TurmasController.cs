using CursoIdioma.API.DTOs.Requests;
using CursoIdioma.API.DTOs.Responses;
using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoIdioma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmasController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarTurmaResponseDto),201)]
        public IActionResult Cadastro(CriarTurmaRequestDto dto)
        {
            try
            {
                var turma = new Turma()
                {
                    Numero=dto.Numero,
                    AnoLetivo=dto.AnoLetivo,
                    Nivel=dto.Nivel,
                    Id=Guid.NewGuid()
                };

                _turmaService.Criar(turma);

                var response = new CriarTurmaResponseDto()
                {
                    Numero = turma.Numero,
                    AnoLetivo=turma.AnoLetivo,
                    Nivel = turma.Nivel,
                    Id=turma.Id
                };

                return StatusCode(201, response);
            }
            catch(ApplicationException e)
            {
                return StatusCode(422, new {e.Message});
            }
            catch (Exception e) 
            {
                return StatusCode(500, new { e.Message });
            }


        }

        [HttpPut]
        [ProducesResponseType(typeof(AlterarTurmaResponseDto),200)]
        public IActionResult Alteracao(AlterarTurmaRequestDto dto)
        {
            try
            {
                var turma = new Turma()
                {
                    Numero = dto.Numero,
                    AnoLetivo = dto.AnoLetivo,
                    Nivel = dto.Nivel,
                    Id = dto.Id
                };
                _turmaService.Alterar(turma);

                var response = new AlterarTurmaResponseDto()
                {
                    Id= turma.Id,
                    Numero = turma.Numero,
                    AnoLetivo=turma.AnoLetivo,
                    Nivel=turma.Nivel,
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
        [ProducesResponseType(typeof(List<ConsultarTurmaResponseDto>),200)]
        public IActionResult Consulta()
        {
            try
            {
                var response = _turmaService.Consultar();
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirTurmaResponseDto),200)]
        public IActionResult Exclusao(Guid id)
        {
            try
            {
                var turma = _turmaService.ConsultarUmaTurma(id);
                _turmaService.Excluir(id);

                var response = new ExcluirTurmaResponseDto()
                {
                    Id= turma.Id,
                    Numero= turma.Numero,
                    AnoLetivo= turma.AnoLetivo,
                    Nivel= turma.Nivel,
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
