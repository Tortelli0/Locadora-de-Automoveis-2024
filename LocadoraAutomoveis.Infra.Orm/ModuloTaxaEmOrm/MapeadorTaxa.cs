﻿using LocadoraAutomoveis.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxaEmOrm;

public class MapeadorTaxa : IEntityTypeConfiguration<Taxa>
{
	
	public void Configure(EntityTypeBuilder<Taxa> builder)
	{
		builder.ToTable("TBTaxa");

		builder.Property(t => t.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(t => t.Nome)
			.HasColumnType("varchar(200)")
			.IsRequired();

		builder.Property(t => t.Valor)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(t => t.TipoCobranca)
			.HasColumnType("int")
			.IsRequired();

        builder.Property(c => c.EmpresaId)
            .HasColumnType("int")
            .HasColumnName("Empresa_Id")
            .IsRequired();

        builder.HasOne(c => c.Empresa)
            .WithMany()
            .HasForeignKey(f => f.EmpresaId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
    }
}
