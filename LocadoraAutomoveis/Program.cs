using System.Reflection;
using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxa;
using LocadoraAutomoveis.Aplicacao.Serviços;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxaEmOrm;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;

namespace LocadoraAutomoveis.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<LocadoraDbContext>();

        builder.Services.AddScoped<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveisEmOrm>();
        builder.Services.AddScoped<IRepositorioAutomoveis, RepositorioAutomoveisEmOrm>();
        builder.Services.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaEmOrm>();
        builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxaEmOrm>();

        builder.Services.AddScoped<ServicoGrupoAutomoveis>();
        builder.Services.AddScoped<ServicoAutomovel>();
        builder.Services.AddScoped<ServicoPlanoCobranca>();
        builder.Services.AddScoped<ServicoTaxa>();

        builder.Services.AddScoped<FotoValueResolver>();
        builder.Services.AddScoped<GrupoAutomoveisResolver>();

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}