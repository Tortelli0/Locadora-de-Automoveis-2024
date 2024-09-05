using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloTaxa;

public interface IRepositorioTaxa : IRepositorio<Taxa>
{
    List<Taxa> SelecionarMuitos(List<int> idsTaxasSelecionadas);
}
