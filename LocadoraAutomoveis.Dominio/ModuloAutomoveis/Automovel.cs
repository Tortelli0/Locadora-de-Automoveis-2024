using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis;

public class Automovel : EntidadeBase
{
	public string Modelo { get; set; }
	public string Marca { get; set; }
	public string Cor { get; set; }
	public TipoCombustivelEnum TipoCombustivelEnum { get; set; }
	public int CapacidadeLitros { get; set; }
	public byte[] Foto { get; set; }

	public int GrupoAutomoveisId { get; set; }
	public GrupoAutomoveis? GrupoAutomoveis { get; set; }

	public bool Alugado { get; set; }

    protected Automovel() {}

    public Automovel(string modelo, string marca, string cor, TipoCombustivelEnum tipoCombustivelEnum, int capacidadeLitros, int grupoAutomoveisId)
    {
	    Modelo = modelo;
	    Marca = marca;
	    Cor = cor;
	    TipoCombustivelEnum = tipoCombustivelEnum;
	    CapacidadeLitros = capacidadeLitros;
	    GrupoAutomoveisId = grupoAutomoveisId;
    }

    public override List<string> Validar()
	{
		List<string> erros = [];

		if (string.IsNullOrEmpty(Modelo.Trim()))
			erros.Add("O Modelo é obrigatório.");

		if (string.IsNullOrEmpty(Marca.Trim()))
			erros.Add("A Marca é obrigatória.");

		if (CapacidadeLitros <= 0)
			erros.Add("A Capacidade de Litros é obrigatória.");

		if (GrupoAutomoveisId == 0)
			erros.Add("O grupo de Automoveis é obrigatório.");

		return erros;
	}

    public void Alugar()
    {
        Alugado = true;
    }

    public void Desocupar()
    {
        Alugado = false;
    }
}