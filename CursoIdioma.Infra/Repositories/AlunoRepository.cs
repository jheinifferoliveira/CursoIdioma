using CursoIdioma.Domain.Entities;
using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Infra.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public Aluno? ConsultarAluno(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Aluno>()
                    .Where(a=>a.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}
