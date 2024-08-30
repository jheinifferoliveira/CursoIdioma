using CursoIdioma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        void Criar(Aluno aluno, Guid turmaId);
        void Alterar(Aluno aluno);
        List<Aluno> ConsultarTodos();
        Aluno? ConsultarUmAluno(Guid id);
        void Excluir (Guid id);
    }
}
