using CursoIdioma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Interfaces.Services
{
    public interface IMatriculaService
    {
        void Criar(Matricula matricula);
        void Excluir (Guid turmaId, Guid alunoId);
    }
}
