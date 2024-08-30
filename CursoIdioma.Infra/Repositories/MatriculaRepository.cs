using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Infra.Repositories
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public Matricula? ConsultarMatricula(Guid turmaId, Guid alunoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .FirstOrDefault(m => m.TurmaId == turmaId && m.AlunoId == alunoId);
            }
        }

        public int? QuantidadeMatriculas(Guid turmaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .Count(m => m.TurmaId == turmaId);
            }
        }

        public bool VerificarMatriculaDeAluno(Guid alunoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .Count(m => m.AlunoId == alunoId) > 0;
            }
        }

        public bool VerificarMatriculaDeTurma(Guid turmaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .Count(m => m.TurmaId == turmaId) > 0;
            }
        }
    }
}
