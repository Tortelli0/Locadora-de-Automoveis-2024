using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

public class GrupoAutomoveis : EntidadeBase
{
    public string Nome { get; set; }
    public List<Automovel> Automoveis { get; set; } = [];

    protected GrupoAutomoveis() { }

    public GrupoAutomoveis(string nome)
    {
        Nome = nome;
        Automoveis = new List<Automovel>();
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 3)
            erros.Add("O nome é obrigatório");

        return erros;
    }
}
