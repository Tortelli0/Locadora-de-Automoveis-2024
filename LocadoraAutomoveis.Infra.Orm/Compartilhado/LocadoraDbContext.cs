using LocadoraAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado;

public class LocadoraDbContext : IdentityDbContext<Usuario, Perfil, int>
{
    public DbSet<GrupoAutomoveis> GrupoAutomoveis { get; set; }
	public DbSet<Automovel> Automoveis { get; set; }
    public DbSet<PlanoCobranca> PlanosCobranca { get; set; }
    public DbSet<Taxa> Taxas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Condutor> Condutores { get; set; }
    public DbSet<ConfiguracaoCombustivel> ConfiguracoesCombustiveis { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config
            .GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(LocadoraDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}

