using CursoIdioma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Interfaces.Repositories
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        Turma? ConsultarTurma(Guid id);
    }
}
