using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Upper.Desafio.Persistence.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
