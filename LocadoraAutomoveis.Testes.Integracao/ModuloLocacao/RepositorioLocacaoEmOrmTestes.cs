﻿using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Testes.Integracao.Compartilhado;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloLocacao;

[TestClass]
[TestCategory("Integração")]
public class RepositorioLocacaoEmOrmTestes : RepositorioEmOrmTestesBase
{
    [TestMethod]
    public void Deve_Inserir_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

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

        var configCombustivel = Builder<ConfiguracaoCombustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var locacao = Builder<Locacao>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.AutomovelId = automovel.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        // Act
        repositorioLocacao.Inserir(locacao);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);

        Assert.IsNotNull(locacaoSelecionada);
        Assert.AreEqual(locacao, locacaoSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

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

        var configCombustivel = Builder<ConfiguracaoCombustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var locacao = Builder<Locacao>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.AutomovelId = automovel.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        locacao.DevolucaoPrevista = locacao.DevolucaoPrevista.AddDays(2);

        // Act
        repositorioLocacao.Editar(locacao);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);

        Assert.IsNotNull(locacaoSelecionada);
        Assert.AreEqual(locacao, locacaoSelecionada);
    }

    [TestMethod]
    public void Deve_Excluir_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomoveisId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

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

        var configCombustivel = Builder<ConfiguracaoCombustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var locacao = Builder<Locacao>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.AutomovelId = automovel.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        // Act
        repositorioLocacao.Excluir(locacao);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);
        var locacoes = repositorioLocacao.SelecionarTodos();

        Assert.IsNull(locacaoSelecionada);
        Assert.AreEqual(0, locacoes.Count);
    }
}