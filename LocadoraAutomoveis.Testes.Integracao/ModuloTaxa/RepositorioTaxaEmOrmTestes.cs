using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxaEmOrm;
using LocadoraAutomoveis.Testes.Integracao.Compartilhado;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloTaxa;

[TestClass]
[TestCategory("Integração")]
public class RepositorioTaxaEmOrmTestes : RepositorioEmOrmTestesBase
{
	[TestMethod]
	public void Deve_Inserir_Taxa()
	{
		var taxa = Builder<Taxa>
			.CreateNew()
			.With(t => t.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

		repositorioTaxa.Inserir(taxa);

		var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

		Assert.IsNotNull(taxaSelecionada);
		Assert.AreEqual(taxa, taxaSelecionada);
	}

	[TestMethod]
	public void Deve_Editar_Taxa()
	{
		var taxa = Builder<Taxa>
			.CreateNew()
			.With(t => t.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

		taxa.Nome = "Taxa Atualizada";
		taxa.Valor = 100.0m;

		repositorioTaxa.Editar(taxa);

		var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

		Assert.IsNotNull(taxaSelecionada);
		Assert.AreEqual(taxa, taxaSelecionada);
	}

	[TestMethod]
	public void Deve_Excluir_Taxa()
	{
		var taxa = Builder<Taxa>
			.CreateNew()
			.With(t => t.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

		repositorioTaxa.Excluir(taxa);

		var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

		var taxas = repositorioTaxa.SelecionarTodos();

		Assert.IsNull(taxaSelecionada);
		Assert.AreEqual(0, taxas.Count);
	}
}