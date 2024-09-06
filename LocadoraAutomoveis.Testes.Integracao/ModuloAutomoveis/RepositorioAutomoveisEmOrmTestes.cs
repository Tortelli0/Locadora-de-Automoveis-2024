using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Testes.Integracao.Compartilhado;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloAutomoveis;

[TestClass]
[TestCategory("Integração")]
public class RepositorioAutomoveisEmOrmTestes : RepositorioEmOrmTestesBase
{
	[TestMethod]
	public void Deve_Inserir_Automoveis()
	{
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculo = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculoSelecionado = repositorioAutomovel.SelecionarPorId(veiculo.Id);

        Assert.IsNotNull(veiculoSelecionado);
        Assert.AreEqual(veiculo, veiculoSelecionado);
    }

	[TestMethod]
	public void Deve_Editar_Automoveis()
	{
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculo = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        veiculo.Modelo = "Novo Modelo";

        repositorioAutomovel.Editar(veiculo);

        var veiculoSelecionado = repositorioAutomovel.SelecionarPorId(veiculo.Id);

        Assert.IsNotNull(veiculoSelecionado);
        Assert.AreEqual(veiculo, veiculoSelecionado);
    }

	[TestMethod]
	public void Deve_Excluir_Automoveis()
	{
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculo = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        repositorioAutomovel.Excluir(veiculo);

        var veiculoSelecionado = repositorioAutomovel.SelecionarPorId(veiculo.Id);

        var veiculos = repositorioAutomovel.SelecionarTodos();

        Assert.IsNull(veiculoSelecionado);
        Assert.AreEqual(0, veiculos.Count);
	}
}
