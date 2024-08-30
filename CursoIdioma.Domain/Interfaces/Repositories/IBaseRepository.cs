using CursoIdioma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Criar(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        List<TEntity>? ConsultarTodos();
    }
}
