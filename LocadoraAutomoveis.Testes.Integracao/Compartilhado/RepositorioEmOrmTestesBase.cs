﻿using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCombustivel;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxaEmOrm;

namespace LocadoraAutomoveis.Testes.Integracao.Compartilhado;

public abstract class RepositorioEmOrmTestesBase
{
	protected LocadoraDbContext dbContext;
	protected RepositorioTaxaEmOrm repositorioTaxa;
	protected RepositorioClienteEmOrm repositorioCliente;
	protected RepositorioAutomoveisEmOrm repositorioAutomovel;
	protected RepositorioGrupoAutomoveisEmOrm repositorioGrupo;
	protected RepositorioPlanoCobrancaEmOrm repositorioPlano;
    protected RepositorioCondutorEmOrm repositorioCondutor;
	protected RepositorioLocacaoEmOrm repositorioLocacao;
    protected RepositorioConfiguracaoCombustivelEmOrm repositorioCombustivel;

    protected Usuario usuarioAutenticado;

	[TestInitialize]
	public void Inicializar()
	{
		dbContext = new LocadoraDbContext();

		dbContext.Taxas.RemoveRange(dbContext.Taxas);
		dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);
		dbContext.Clientes.RemoveRange(dbContext.Clientes);
		dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
		dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);
		dbContext.Condutores.RemoveRange(dbContext.Condutores);
		dbContext.Locacoes.RemoveRange(dbContext.Locacoes);
		dbContext.ConfiguracoesCombustiveis.RemoveRange(dbContext.ConfiguracoesCombustiveis);
		dbContext.Usuarios.RemoveRange(dbContext.Usuarios);

		usuarioAutenticado = new Usuario()
		{
			UserName = "Empresa Teste",
			Email = "empresa_teste@gmail.com"
		};

		dbContext.Usuarios.Add(usuarioAutenticado);

		dbContext.SaveChanges();

		repositorioTaxa = new RepositorioTaxaEmOrm(dbContext);
		repositorioPlano = new RepositorioPlanoCobrancaEmOrm(dbContext);
		repositorioCliente = new RepositorioClienteEmOrm(dbContext);
		repositorioAutomovel = new RepositorioAutomoveisEmOrm(dbContext);
		repositorioGrupo = new RepositorioGrupoAutomoveisEmOrm(dbContext);
        repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
        repositorioLocacao = new RepositorioLocacaoEmOrm(dbContext);
        repositorioCombustivel = new RepositorioConfiguracaoCombustivelEmOrm(dbContext);

		BuilderSetup.SetCreatePersistenceMethod<Taxa>(repositorioTaxa.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlano.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>(repositorioGrupo.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Locacao>(repositorioLocacao.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<ConfiguracaoCombustivel>(repositorioCombustivel.GravarConfiguracao);
	}
}