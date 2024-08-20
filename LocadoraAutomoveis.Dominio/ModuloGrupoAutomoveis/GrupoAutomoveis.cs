using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

public class GrupoAutomoveis : EntidadeBase
{
    public string Nome { get; set; }
    public int ValorPlanos { get; set; }

    public GrupoAutomoveis() { }

    public GrupoAutomoveis(string nome, int valorPlanos)
    {
        Nome = nome;
        ValorPlanos = valorPlanos;
    }
}
