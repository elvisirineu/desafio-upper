using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Extensions;

namespace Upper.Desafio.Persistence.Entities.Mapping
{
    public class ColheitaMap : EntityTypeConfiguration<Colheita>
    {
        public override void Map(EntityTypeBuilder<Colheita> builder)
        {
            builder.HasKey(t => t.Id);

            builder.ToTable("Colheita");
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Informacao).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Data).HasColumnType("datetime").IsRequired();
            builder.Property(t => t.PesoBruto).HasColumnType("numeric(18,2)").IsRequired();
            
        }
    }
}
