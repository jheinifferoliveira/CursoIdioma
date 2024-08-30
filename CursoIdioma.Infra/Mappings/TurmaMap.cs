using CursoIdioma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdioma.Infra.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("TURMA");
            builder.HasKey(t=>t.Id);

            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Numero).HasColumnName("NUMERO").IsRequired();
            builder.Property(p => p.AnoLetivo).HasColumnName("ANO_LETIVO").IsRequired();
            builder.Property(p => p.Nivel).HasColumnName("NIVEL").IsRequired();
        }
    }
}
