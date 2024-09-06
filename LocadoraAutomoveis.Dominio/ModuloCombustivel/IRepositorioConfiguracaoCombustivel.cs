using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloCombustivel;

public interface IRepositorioConfiguracaoCombustivel
{
    void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel);
    ConfiguracaoCombustivel? ObterConfiguracao(int idEmpresa);
}