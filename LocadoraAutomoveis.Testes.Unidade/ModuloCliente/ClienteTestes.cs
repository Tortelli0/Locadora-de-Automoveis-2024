using LocadoraAutomoveis.Dominio.ModuloCliente;

namespace LocadoraAutomoveis.Testes.Unidade.ModuloCliente;

[TestClass]
[TestCategory("Unidade")]
public class ClienteTestes
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var cliente = new Cliente("Jose", "jose@gmail.com", "99999-9999", TipoCadastroClienteEnum.CPF, "000.000.000-00", "SC", "Lages", "Centro", "Correia Pinto", "55");

		var erros = cliente.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro()
	{
		var cliente = new Cliente("Jose", "jose@gmail.com", "99999-9999", TipoCadastroClienteEnum.CPF, "000.000.000-00", "SC", "", "", "Correia Pinto", "55");

		var erros = cliente.Validar();

		List<string> errosEsperados = 
		[
			"A cidade é obrigatória",
			"O bairro é obrigatório"
		];

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}
