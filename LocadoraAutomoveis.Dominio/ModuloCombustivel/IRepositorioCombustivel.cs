using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloCombustivel;

public interface IRepositorioCombustivel
{
    void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel);
    ConfiguracaoCombustivel? ObterConfiguracao();
}