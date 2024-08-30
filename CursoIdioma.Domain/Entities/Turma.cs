using CursoIdioma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Domain.Entities
{
    public class Turma
    {
        public Guid Id { get; set; }
        public string? Numero { get; set; }
        public string? AnoLetivo { get; set; }
        public Nivel? Nivel { get; set; }

        public List<Matricula>? Matriculas { get; set; }
    }
}
