using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCombustivel;

public class RepositorioConfiguracaoConfiguracaoCombustivelEmOrm : IRepositorioConfiguracaoCombustivel
{
    private readonly LocadoraDbContext dbContext;

    public RepositorioConfiguracaoConfiguracaoCombustivelEmOrm(LocadoraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel)
    {
        dbContext.ConfiguracoesCombustiveis.Add(configuracaoCombustivel);

        dbContext.SaveChanges();
    }

    public ConfiguracaoCombustivel? ObterConfiguracao()
    {
        return dbContext.ConfiguracoesCombustiveis
            .OrderByDescending(c => c.Id)
            .FirstOrDefault();
    }
}