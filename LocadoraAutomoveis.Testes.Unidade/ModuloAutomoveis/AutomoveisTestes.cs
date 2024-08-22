
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Testes.Unidade.ModuloAutomoveis;

[TestClass]
[TestCategory("Unidade")]
public class AutomoveisTestes
{
	[TestMethod]
	public void Deve_Criar_instancia_Valida()
	{
		var grupo = new GrupoAutomoveis("teste");

		var automovel = new Automovel("teste", "teste", "teste", "teste", 10, grupo);

		var erros = automovel.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro()
	{
		var grupo = new GrupoAutomoveis("teste");

		var automovel = new Automovel("", "", "teste", "teste", 10, grupo);

		var erros = automovel.Validar();

		List<string> errosEsperados = ["O Modelo é obrigatório.", "A Marca é obrigatória."];

		Assert.AreEqual(2, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}
