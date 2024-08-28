using System.ComponentModel.DataAnnotations;

namespace LocadoraAutomoveis.Dominio.ModuloTaxa;

public enum TipoCobranca
{
	[Display(Name = "Diária")]
	Diaria,
	Fixa
}