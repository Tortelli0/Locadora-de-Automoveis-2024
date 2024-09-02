using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;

namespace LocadoraAutomoveis.Aplicacao.ModuloCombustivel;

public class ServicoCombustivel
{
    private readonly IRepositorioConfiguracaoCombustivel repositorioConfig;

    public ServicoCombustivel(IRepositorioConfiguracaoCombustivel repositorioConfig)
    {
        this.repositorioConfig = repositorioConfig;
    }

    public Result SalvarConfiguracao(ConfiguracaoCombustivel configuracao)
    {
        repositorioConfig.GravarConfiguracao(configuracao);

        return Result.Ok();;
    }

    public Result<ConfiguracaoCombustivel> ObterConfiguracao()
    {
        var config = repositorioConfig.ObterConfiguracao();

        if (config is null)
        {
            config = new ConfiguracaoCombustivel(
                valorAlcool: 0.0m,
                valorDiesel: 0.0m,
                valorGas: 0.0m,
                valorGasolina: 0.0m
            );
        }

        return Result.Ok();
    }
}
