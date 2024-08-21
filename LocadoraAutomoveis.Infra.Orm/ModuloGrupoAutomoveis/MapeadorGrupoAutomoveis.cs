using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
public class MapeadorGrupoAutomoveis : IEntityTypeConfiguration<GrupoAutomoveis>
{
    public void Configure(EntityTypeBuilder<GrupoAutomoveis> builder)
    {
        builder.ToTable("TBGrupoAutomoveis");

        builder.Property(e => e.Id)
            .HasColumnType("int")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}
