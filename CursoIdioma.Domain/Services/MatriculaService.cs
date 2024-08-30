using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CursoIdioma.Domain.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(ITurmaRepository turmaRepository, IAlunoRepository alunoRepository, IMatriculaRepository matriculaRepository)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
            _matriculaRepository = matriculaRepository;
        }

        public void Criar(Matricula matricula)
        {
            var turma = _turmaRepository.ConsultarTurma(matricula.TurmaId);

            if(turma == null)
            {
                throw new ApplicationException("Turma não encontrada. Verifique o ID informado.");
            }

            var aluno = _alunoRepository.ConsultarAluno(matricula.AlunoId);

            if (aluno == null)
            {
                throw new ApplicationException("Aluno não encontrado. Verifique o ID informado.");
            }

            var matriculaExistente = _matriculaRepository.ConsultarMatricula(turma.Id, aluno.Id);

            if(matriculaExistente != null)
            {
                throw new ApplicationException("Este aluno já foi matriculado nesta turma.");
            }

            var quantidadeMatriculas = _matriculaRepository.QuantidadeMatriculas(turma.Id);

            if(quantidadeMatriculas >= 5)
            {
                throw new ApplicationException("Esta turma já possui 5 alunos matriculados (máximo permitido).");
            }

            _matriculaRepository.Criar(matricula);
        }

        public void Excluir(Guid turmaId, Guid alunoId)
        {
            var matricula = _matriculaRepository.ConsultarMatricula(turmaId, alunoId);

            if (matricula == null)
            {
                throw new ApplicationException("Matrícula não encontrada. Verifique os Ids informados.");
            }

            _matriculaRepository.Excluir(matricula);
        }
    }
}
