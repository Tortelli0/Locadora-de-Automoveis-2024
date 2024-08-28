using LocadoraAutomoveis.Dominio.ModuloTaxa;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace LocadoraAutomoveis.Testes.Unidade.ModuloTaxa;

[TestClass]
[TestCategory("Unidade")]
public class TaxaTestes
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var taxa = new Taxa("Taxa de Serviço", 10.0m, TipoCobranca.Diaria);

		var erros = taxa.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro()
	{
		var taxa = new Taxa("Taxa de Serviço", 0, TipoCobranca.Fixa);

		var erros = taxa.Validar();

		List<string> errosEsperados =
		[
			"O valor precisa ser ao menos 1"
		];

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}
