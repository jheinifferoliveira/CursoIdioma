using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public TurmaService(ITurmaRepository turmaRepository, IMatriculaRepository matriculaRepository)
        {
            _turmaRepository = turmaRepository;
            _matriculaRepository = matriculaRepository;
        }

        public void Alterar(Turma turma)
        {
            var alterarTurma = _turmaRepository.ConsultarTurma(turma.Id);
            if (alterarTurma == null)
            {
                throw new ApplicationException("Turma não encontrada. Verifique o ID informado.");
            }
            alterarTurma.Numero = turma.Numero;
            alterarTurma.AnoLetivo = turma.AnoLetivo;
            alterarTurma.Nivel = turma.Nivel;
            _turmaRepository.Atualizar(alterarTurma);
        }

        public List<Turma> Consultar()
        {
            var consulta = _turmaRepository.ConsultarTodos();
            if (consulta != null)
            {
                return consulta;
            }
            else
            {
                throw new ApplicationException("Não existem turmas cadastradas.");
            }

        }

        public Turma? ConsultarUmaTurma(Guid id)
        {
            var consulta = _turmaRepository.ConsultarTurma(id);
            return consulta;
        }

        public void Criar(Turma turma)
        {            
            _turmaRepository.Criar(turma);
        }

        public void Excluir(Guid id)
        {
            var turma= _turmaRepository.ConsultarTurma(id);

            if (turma == null)
            {
                throw new ApplicationException("Turma não encontrada. Verifique o ID informado.");
            }

            if (_matriculaRepository.VerificarMatriculaDeTurma(turma.Id))
            {
                throw new ApplicationException("A turma não pode ser excluído pois possui matricula(s).");
            }

            _turmaRepository.Excluir(turma);
        }
    }
}
