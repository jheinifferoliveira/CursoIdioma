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
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("ALUNO");
            builder.HasKey(a => a.Id);

            builder.Property(a=>a.Id).HasColumnName("ID");
            builder.Property(a => a.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Cpf).HasColumnName("CPF").IsRequired();
            builder.Property(a => a.Email).HasColumnName("EMAIL").IsRequired();
        }
    }
}
