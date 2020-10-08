using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Extensions;

namespace Upper.Desafio.Persistence.Entities.Mapping
{
    public class ColheitaArvoreMap : EntityTypeConfiguration<ColheitaArvore>
    {
        public override void Map(EntityTypeBuilder<ColheitaArvore> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("ColheitaArvore");
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.ArvoreId).IsRequired();
            builder.Property(t => t.ColheitaId).IsRequired();

            builder.HasOne(t => t.Arvore)
              .WithMany(t => t.ColheitasArvore)
              .HasForeignKey(e => e.ArvoreId);

            builder.HasOne(t => t.Colheita)
              .WithMany(t => t.ColheitasArvore)
              .HasForeignKey(e => e.ColheitaId);


        }
    }
}
