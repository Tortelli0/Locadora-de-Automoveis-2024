using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Testes.Integracao.Compartilhado;
using NuGet.Frameworks;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloCondutor;

[TestClass]
[TestCategory("Integração")]
public class RepositorioCondutorEmOrmTestes : RepositorioEmOrmTestesBase
{
    [TestMethod]
    public void Deve_Inserir_Condutor()
    {
        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        repositorioCondutor.Inserir(condutor);

        var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

        Assert.IsNotNull(condutorSelecionado);
        Assert.AreEqual(condutor, condutorSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_Condutor()
    {
        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        condutor.Nome = "Messias";
        condutor.Telefone = "49 90000-0000";

        repositorioCondutor.Editar(condutor);

        var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

        Assert.IsNotNull(condutorSelecionado);
        Assert.AreEqual(condutor, condutorSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_Condutor()
    {
        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        repositorioCondutor.Excluir(condutor);

        var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

        var condutores = repositorioCondutor.SelecionarTodos();

        Assert.IsNull(condutorSelecionado);
        Assert.AreEqual(0, condutores.Count);
    }
}