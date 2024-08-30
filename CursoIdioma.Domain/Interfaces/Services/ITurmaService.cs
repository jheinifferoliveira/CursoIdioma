using CursoIdioma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Interfaces.Services
{
    public interface ITurmaService
    {
        void Criar(Turma turma);
        void Alterar(Turma turma);
        List<Turma> Consultar();
        Turma? ConsultarUmaTurma(Guid id);
        void Excluir(Guid id);
    }
}
