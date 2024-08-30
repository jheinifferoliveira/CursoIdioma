using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        public void Criar(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Atualizar(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }

        public void Excluir(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<TEntity>? ConsultarTodos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }
    }
}
