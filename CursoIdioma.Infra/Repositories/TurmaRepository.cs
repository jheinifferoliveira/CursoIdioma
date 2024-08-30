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
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public Turma? ConsultarTurma(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Turma>()
                   .Where(t => t.Id == id).FirstOrDefault();
            }
        }    
    }
}
