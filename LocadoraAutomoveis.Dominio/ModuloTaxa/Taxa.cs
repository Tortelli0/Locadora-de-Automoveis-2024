using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloLocacao;

namespace LocadoraAutomoveis.Dominio.ModuloTaxa;

public class Taxa : EntidadeBase
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public TipoCobranca TipoCobranca { get; set; }
    public List<Locacao> Locacoes { get; set; }

    protected Taxa()
    {
        Locacoes = new List<Locacao>();
    }

    public Taxa(string nome, decimal valor, TipoCobranca tipoCobranca) : this()
    {
	    Nome = nome;
	    Valor = valor;
	    TipoCobranca = tipoCobranca;
    }

    public override List<string> Validar()
	{
        List<string> erros = [];

        if (Nome.Length < 3)
            erros.Add("O nome precisa conter ao menos 3 caracteres");

        if (Valor < 1.0m)
            erros.Add("O valor precisa ser ao menos 1");

        return erros;
    }

    public override string ToString()
    {
        return $"{Valor.ToString("C2")}\t{Nome}\t({TipoCobranca.ToString()})";
    }

    public decimal CalcularValor(int quantidadeDiasPercorridos)
    {
        if (TipoCobranca == TipoCobranca.Diaria)
            return Valor * quantidadeDiasPercorridos;

        return Valor;
    }
}