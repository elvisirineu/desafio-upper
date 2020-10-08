using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Pattern.Ef.DataContext;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Persistence.Entities.Mapping;
using Upper.Desafio.Persistence.Extensions;

namespace Upper.Desafio.Persistence.Context
{
    public class UpperDesafioContext : DbContext, IDataContext
    {
        public UpperDesafioContext(DbContextOptions<UpperDesafioContext> options) : base(options)
        {
        }

        public UpperDesafioContext()
        {

        }

        public DbSet<Arvore> Arvores { get; set; }
        public DbSet<Colheita> Colheitas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ColheitaArvore> ColheitaArvores { get; set; }
        public DbSet<GrupoArvore> GrupoArvores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EspecieMap());
            modelBuilder.AddConfiguration(new ArvoreMap());
            modelBuilder.AddConfiguration(new ColheitaMap());
            modelBuilder.AddConfiguration(new ColheitaArvoreMap());
            modelBuilder.AddConfiguration(new GrupoMap());
            modelBuilder.AddConfiguration(new GrupoArvoreMap());

            modelBuilder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var configuration = new ConfigurationBuilder()
                //     .SetBasePath(Directory.GetCurrentDirectory() + "/../../Api/Upper.Desafio.Api")
                //     .AddJsonFile("appsettings.json", false, true)
                //     .Build();
                //var connectionString = configuration.GetConnectionString("UpperDesafioConnection");
                optionsBuilder.UseSqlServer("Data Source=localhost,1435;Initial Catalog=UpperDesafio;User ID=sa;Password=upper.desafio@123");
            }
        }
    }
}
