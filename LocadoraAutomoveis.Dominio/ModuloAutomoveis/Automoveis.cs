using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis;
public class Automoveis : EntidadeBase
{
	public GrupoAutomoveis GrupoAutomoveis { get; set; }
	public string Modelo { get; set; }
	public string Marca { get; set; }
	public string Cor { get; set; }
	public string TipoCombustivel { get; set; }
	public int CapacidadeLitros { get; set; }

    protected Automoveis() {}

    public Automoveis(string modelo, string marca, string cor, string tipoCombustivel, int capacidadeLitros, GrupoAutomoveis grupoAutomoveis)
    {
	    Modelo = modelo;
	    Marca = marca;
	    Cor = cor;
	    TipoCombustivel = tipoCombustivel;
	    CapacidadeLitros = capacidadeLitros;
	    GrupoAutomoveis = grupoAutomoveis;
    }


    public override List<string> Validar()
	{
		List<string> erros = [];

		if (GrupoAutomoveis is null)
			erros.Add("O grupo de Automoveis é obrigatório.");

		if (string.IsNullOrEmpty(Modelo.Trim()))
			erros.Add("O Modelo é obrigatório.");

		if (string.IsNullOrEmpty(Marca.Trim()))
			erros.Add("A Marca é obrigatória.");

		if (string.IsNullOrEmpty(TipoCombustivel.Trim()))
			erros.Add("O Tipo de combustivel é obrigatório.");

		if (CapacidadeLitros >= 0)
			erros.Add("A Capacidade de Litros é obrigatória.");

		return erros;
	}
}
