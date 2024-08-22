using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;

public class MapeadorAutomoveis : IEntityTypeConfiguration<Automoveis>
{
	public void Configure(EntityTypeBuilder<Automoveis> builder)
	{
		builder.ToTable("TBAutomoveis");

		builder.Property(a => a.Id)
			.HasColumnType("int")
			.IsRequired()
			.ValueGeneratedOnAdd();

		builder.Property(a => a.Modelo)
			.IsRequired()
			.HasColumnType("varchar(50)");

		builder.Property(a => a.Marca)
			.IsRequired()
			.HasColumnType("varchar(50)");

		builder.Property(a => a.TipoCombustivel)
			.IsRequired()
			.HasColumnType("varchar(50)");

		builder.Property(a => a.CapacidadeLitros)
			.IsRequired()
			.HasColumnType("int");

		builder.HasOne(a => a.GrupoAutomoveis)
			.WithMany(g => g.Automoveis)
			.HasConstraintName("FK_TbAutomovel_TbGrupoAutomovel")
			.OnDelete(DeleteBehavior.Restrict);
	}
}
