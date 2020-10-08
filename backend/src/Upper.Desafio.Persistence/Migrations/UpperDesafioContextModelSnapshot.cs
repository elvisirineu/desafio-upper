﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Upper.Desafio.Persistence.Context;

namespace Upper.Desafio.Persistence.Migrations
{
    [DbContext(typeof(UpperDesafioContext))]
    partial class UpperDesafioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.Arvore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("EspecieId")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecieId");

                    b.ToTable("Arvore");
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.Colheita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Informacao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("PesoBruto")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Colheita");
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.ColheitaArvore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArvoreId")
                        .HasColumnType("int");

                    b.Property<int>("ColheitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArvoreId");

                    b.HasIndex("ColheitaId");

                    b.ToTable("ColheitaArvore");
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Especie");
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.GrupoArvore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArvoreId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArvoreId");

                    b.HasIndex("GrupoId");

                    b.ToTable("GrupoArvore");
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.Arvore", b =>
                {
                    b.HasOne("Upper.Desafio.Domain.Entities.Especie", "Especie")
                        .WithMany("Arvores")
                        .HasForeignKey("EspecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.ColheitaArvore", b =>
                {
                    b.HasOne("Upper.Desafio.Domain.Entities.Arvore", "Arvore")
                        .WithMany("ColheitasArvore")
                        .HasForeignKey("ArvoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Upper.Desafio.Domain.Entities.Colheita", "Colheita")
                        .WithMany("ColheitasArvore")
                        .HasForeignKey("ColheitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Upper.Desafio.Domain.Entities.GrupoArvore", b =>
                {
                    b.HasOne("Upper.Desafio.Domain.Entities.Arvore", "Arvore")
                        .WithMany("GruposArvore")
                        .HasForeignKey("ArvoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Upper.Desafio.Domain.Entities.Grupo", "Grupo")
                        .WithMany("GruposArvore")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
