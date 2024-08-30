using CursoIdioma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Interfaces.Repositories
{
    public interface IMatriculaRepository : IBaseRepository<Matricula>
    {
        Matricula? ConsultarMatricula(Guid turmaId, Guid alunoId);
        int? QuantidadeMatriculas(Guid turmaId);

        bool VerificarMatriculaDeAluno(Guid alunoId);
        bool VerificarMatriculaDeTurma(Guid turmaId);
    }
}
