using System.ComponentModel.DataAnnotations;

namespace LocadoraAutomoveis.Dominio.ModuloCliente;

public enum TipoCadastroClienteEnum
{
	[Display(Name = "Pessoa Física")] CPF,
	[Display(Name = "Pessoa Jurídica")]	CNPJ
}