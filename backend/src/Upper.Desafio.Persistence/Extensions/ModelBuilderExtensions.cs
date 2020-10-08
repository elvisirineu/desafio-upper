using Microsoft.EntityFrameworkCore;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Seed;

namespace Upper.Desafio.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especie>().HasData(
                EspecieSeed.Data()
            );

            modelBuilder.Entity<Arvore>().HasData(
                ArvoreSeed.Data()
            );
        }
    }
}
