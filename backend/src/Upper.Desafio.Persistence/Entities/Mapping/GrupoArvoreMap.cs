using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Extensions;

namespace Upper.Desafio.Persistence.Entities.Mapping
{
    public class GrupoArvoreMap : EntityTypeConfiguration<GrupoArvore>
    {
        public override void Map(EntityTypeBuilder<GrupoArvore> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("GrupoArvore");
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.ArvoreId).IsRequired();
            builder.Property(t => t.GrupoId).IsRequired();


            builder.HasOne(t => t.Arvore)
             .WithMany(t => t.GruposArvore)
             .HasForeignKey(e => e.ArvoreId);

            builder.HasOne(t => t.Grupo)
            .WithMany(t => t.GruposArvore)
            .HasForeignKey(e => e.GrupoId);

        }
    }
}
