using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Extensions;

namespace Upper.Desafio.Persistence.Entities.Mapping
{
    public class ArvoreMap : EntityTypeConfiguration<Arvore>
    {
        public override void Map(EntityTypeBuilder<Arvore> builder)
        {
            builder.HasKey(t => t.Id);

            builder.ToTable("Arvore");
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Descricao).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();

            builder.HasOne(t => t.Especie)
              .WithMany(t => t.Arvores)
              .HasForeignKey(d => d.EspecieId);

           
        }
    }
}
