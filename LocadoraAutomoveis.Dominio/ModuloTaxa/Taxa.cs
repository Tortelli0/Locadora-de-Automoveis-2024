using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloTaxa;

public class Taxa : EntidadeBase
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public TipoCobranca TipoCobranca { get; set; }

    protected Taxa() { }

    public Taxa(TipoCobranca tipoCobranca, decimal valor, string nome)
    {
	    TipoCobranca = tipoCobranca;
	    Valor = valor;
	    Nome = nome;
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
}
