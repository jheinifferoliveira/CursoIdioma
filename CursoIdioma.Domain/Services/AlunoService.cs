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
    public class AlunoService : IAlunoService
    { 
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public AlunoService(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMatriculaRepository matriculaRepository)
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _matriculaRepository = matriculaRepository;
        }

        public void Alterar(Aluno aluno)
        {
            var alterarAluno=_alunoRepository.ConsultarAluno(aluno.Id);

            alterarAluno.Nome=aluno.Nome;
            alterarAluno.Cpf=aluno.Cpf;
            alterarAluno.Email=aluno.Email;

            _alunoRepository.Atualizar(alterarAluno);
        }

        public List<Aluno> ConsultarTodos()
        {
           var consulta = _alunoRepository.ConsultarTodos();
            if (consulta != null)
            {
                return consulta;
            }
            else
            {
                throw new ApplicationException("Não existem alunos cadastrados.");
            }
        }
        public Aluno? ConsultarUmAluno(Guid id)
        {
            var consulta = _alunoRepository.ConsultarAluno(id);
            return consulta;
        }

        public void Criar(Aluno aluno, Guid turmaId)
        {
            var turma = _turmaRepository.ConsultarTurma(turmaId);

            if(turma == null)
            {
                throw new ApplicationException("A turma não foi encontrada. Verifique o ID Informado.");
            }

            _alunoRepository.Criar(aluno);

            var matricula = new Matricula();
            matricula.TurmaId = turma.Id;
            matricula.AlunoId = aluno.Id;

            _matriculaRepository.Criar(matricula);
        }

        public void Excluir(Guid id)
        {
            var aluno= _alunoRepository.ConsultarAluno(id);

            if(aluno == null)
            {
                throw new ApplicationException("O aluno não foi encontrado. Verifique o ID Informado.");
            }

            if(_matriculaRepository.VerificarMatriculaDeAluno(aluno.Id))
            {
                throw new ApplicationException("O aluno não pode ser excluído pois está matriculado em turma(s).");
            }

            _alunoRepository.Excluir(aluno);           
        }
    }
}
