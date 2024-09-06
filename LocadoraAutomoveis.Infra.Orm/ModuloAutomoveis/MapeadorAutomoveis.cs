using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;

public class MapeadorAutomoveis : IEntityTypeConfiguration<Automovel>
{
	public void Configure(EntityTypeBuilder<Automovel> builder)
	{
		builder.ToTable("TBAutomoveis");

		builder.Property(a => a.Id)
			.HasColumnType("int")
			.IsRequired()
			.ValueGeneratedOnAdd();

		builder.Property(a => a.Modelo)
			.IsRequired()
			.HasColumnType("varchar(100)");

		builder.Property(a => a.Marca)
			.IsRequired()
			.HasColumnType("varchar(100)");

		builder.Property(a => a.TipoCombustivelEnum)
			.IsRequired()
			.HasColumnType("int");

		builder.Property(a => a.CapacidadeLitros)
			.IsRequired()
			.HasColumnType("int");

		builder.Property(a => a.Foto)
			.HasColumnType("varbinary(max)")
			.HasDefaultValue(Array.Empty<byte>());

		builder.Property(a => a.GrupoAutomoveisId)
			.IsRequired()
			.HasColumnType("int");

		builder.HasOne(a => a.GrupoAutomoveis)
			.WithMany(g => g.Automoveis)
			.HasConstraintName("FK_TbAutomovel_TbGrupoAutomovel")
			.OnDelete(DeleteBehavior.Restrict);

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
