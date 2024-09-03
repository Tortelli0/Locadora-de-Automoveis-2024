using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloTaxa;

namespace LocadoraAutomoveis.Dominio.ModuloLocacao;
public class Locacao : EntidadeBase
{
    public int CondutorId { get; set; }
    public Condutor? Condutor { get; set; }

    public int AutomovelId { get; set; }
    public Automovel? Automovel { get; set; }

    public int ConfiguracaoCombustivelId { get; set; }
    public ConfiguracaoCombustivel? ConfiguracaoCombustivel { get; set; }

    public TipoPlanoCobrancaEnum TipoPlano { get; set; }
    public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

    public int QuilometragemPercorrida { get; set; }

    public DateTime DataLocacao { get; set; }
    public DateTime DevolucaoPrevista  { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public List<Taxa> TaxasSelecionadas { get; set; }

    protected Locacao()
    {
        TaxasSelecionadas = new List<Taxa>();
        DataDevolucao = null;
        MarcadorCombustivel = MarcadorCombustivelEnum.Completo;
    }

    public Locacao(int automovelId, int condutorId, int configuracaoCombustivelId, TipoPlanoCobrancaEnum planoCobranca, DateTime dataLocacao, DateTime devolucaoPrevista) : this()
    {
        AutomovelId = automovelId;
        CondutorId = condutorId;
        ConfiguracaoCombustivelId = configuracaoCombustivelId;
        TipoPlano = planoCobranca;
        DataLocacao = dataLocacao;
        DevolucaoPrevista = devolucaoPrevista;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (CondutorId == 0)
            erros.Add("O condutor é obrigatório");

        if (AutomovelId == 0)
            erros.Add("O Automovel é obrigatório");

        if (DataLocacao == DateTime.MinValue)
            erros.Add("Seleciona a data da locação");

        if (DataDevolucao == DateTime.MinValue)
            erros.Add("Selecione a data prevista da entrega");

        if (DataDevolucao < DataLocacao)
            erros.Add("A data prevista da entrega não pode ser menor que data da locação");

        return erros;
    }

    public void Abrir()
    {
        if (Automovel is null) return;

        Automovel.Alugar();
    }

    public void RealizarDevolucao()
    {
        DataDevolucao = DateTime.Now;
        
        if (Automovel is null) return;

        Automovel.Desocupar();
    }

    public bool TemMulta()
    {
        if (DataDevolucao is null)
            return (DateTime.Now - DevolucaoPrevista).Days > 0;

        return (DataDevolucao - DevolucaoPrevista).Value.Days > 0;
    }
}