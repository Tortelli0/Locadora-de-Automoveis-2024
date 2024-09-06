using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadoraAutomoveis.Testes.Integracao.Compartilhado;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloPlanoCobranca;

[TestClass]
[TestCategory("Integração")]
public class RepositorioPlanoCobrancaEmOrmTestes : RepositorioEmOrmTestesBase
{
	[TestMethod]
	public void Deve_Inserir_PlanoCobranca()
	{
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        repositorioPlano.Inserir(planoCobranca);

        var planoCobrancaSelecionado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

	[TestMethod]
	public void Deve_Editar_PlanoCobranca()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

		var planoCobranca = Builder<PlanoCobranca>
			.CreateNew()
			.With(p => p.Id = 0)
			.With(p => p.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

		planoCobranca.PrecoDiarioPlanoDiario = 200.0m;

		repositorioPlano.Editar(planoCobranca);

		var planoCobrancaSelecionado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

		Assert.IsNotNull(planoCobrancaSelecionado);
		Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
	}

	[TestMethod]
	public void Deve_Excluir_PlanoCobranca()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

		var planoCobranca = Builder<PlanoCobranca>
			.CreateNew()
			.With(p => p.Id = 0)
			.With(p => p.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

		repositorioPlano.Excluir(planoCobranca);

		var planoCobrancaSelecionado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

		var planosCobranca = repositorioPlano.SelecionarTodos();

		Assert.IsNull(planoCobrancaSelecionado);
		Assert.AreEqual(0, planosCobranca.Count);
	}
}
