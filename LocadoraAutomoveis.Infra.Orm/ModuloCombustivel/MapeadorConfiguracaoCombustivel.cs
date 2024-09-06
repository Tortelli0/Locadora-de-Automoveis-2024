using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCombustivel;

public class MapeadorConfiguracaoCombustivel : IEntityTypeConfiguration<ConfiguracaoCombustivel>
{
    public void Configure(EntityTypeBuilder<ConfiguracaoCombustivel> builder)
    {
        builder.ToTable("TBConfiguracaoCombustivel");

        builder.Property(c => c.DataCriacao)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(c => c.ValorGasolina)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(c => c.ValorGas)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(c => c.ValorDiesel)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(c => c.ValorAlcool)
            .HasColumnType("decimal(18,2)")
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
