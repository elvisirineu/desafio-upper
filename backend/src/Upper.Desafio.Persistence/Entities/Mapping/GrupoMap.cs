using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Extensions;

namespace Upper.Desafio.Persistence.Entities.Mapping
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        public override void Map(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.ToTable("Grupo");
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Nome).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Descricao).HasMaxLength(300).HasColumnType("varchar(300)").IsRequired();

        }
    }
}
