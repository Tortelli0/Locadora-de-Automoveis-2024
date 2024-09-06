using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Testes.Integracao.Compartilhado;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloGrupoAutomoveis;

[TestClass]
[TestCategory("Integração")]
public class RepositorioGrupoAutomoveisEmOrmTestes : RepositorioEmOrmTestesBase
{
    [TestMethod]
    public void Deve_Inserir_GrupoAutomoveis()
    {
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        repositorioGrupo.Inserir(grupo);

        var grupoSelecionado = repositorioGrupo.SelecionarPorId(grupo.Id);

        Assert.IsNotNull(grupoSelecionado);
        Assert.AreEqual(grupo, grupoSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_GrupoAutomoveis()
    {
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        grupo.Nome = "Teste de Edição";
        repositorioGrupo.Editar(grupo);

        var grupoSelecionado = repositorioGrupo.SelecionarPorId(grupo.Id);

        Assert.IsNotNull(grupoSelecionado);
        Assert.AreEqual(grupo, grupoSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_GrupoAutomoveis()
    {
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        repositorioGrupo.Excluir(grupo);

        var grupoSelecionado = repositorioGrupo.SelecionarPorId(grupo.Id);

        var grupos = repositorioGrupo.SelecionarTodos();

        Assert.IsNull(grupoSelecionado);
        Assert.AreEqual(0, grupos.Count);
    }
}
