﻿// <auto-generated />
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    [Migration("20240827175150_add-PlanoCobranca")]
    partial class addPlanoCobranca
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloAutomoveis.Automovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CapacidadeLitros")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupoAutomoveisId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomoveisId");

                    b.ToTable("TBAutomoveis", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomoveis", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoAutomoveisId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoDiarioPlanoControlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoDiarioPlanoDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoDiarioPlanoLivre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoQuilometroExtrapoladoPlanoControlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoQuilometroPlanoDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuilometrosDisponiveisPlanoControlado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomoveisId");

                    b.ToTable("TBPlanoCobranca", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloAutomoveis.Automovel", b =>
                {
                    b.HasOne("LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", "GrupoAutomoveis")
                        .WithMany("Automoveis")
                        .HasForeignKey("GrupoAutomoveisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_TbAutomovel_TbGrupoAutomovel");

                    b.Navigation("GrupoAutomoveis");
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", "GrupoAutomoveis")
                        .WithMany()
                        .HasForeignKey("GrupoAutomoveisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoAutomoveis");
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", b =>
                {
                    b.Navigation("Automoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
