using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;

public class ServicoPlanoCobranca
{
	private readonly IRepositorioPlanoCobranca repositoiroPlanoCobranca;

	public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositoiroPlanoCobranca)
	{
		this.repositoiroPlanoCobranca = repositoiroPlanoCobranca;
	}

	public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
	{
		repositoiroPlanoCobranca.Inserir(planoCobranca);

		return Result.Ok(planoCobranca);
	}

	public Result<PlanoCobranca> Editar(PlanoCobranca planoCobrancaAtualizado)
	{
		var planoCobranca = repositoiroPlanoCobranca.SelecionarPorId(planoCobrancaAtualizado.Id);

		if (planoCobranca is null)
			return Result.Fail("O plano de cobrança não foi encontrado!");

		planoCobranca.GrupoAutomoveisId = planoCobrancaAtualizado.GrupoAutomoveisId;
		planoCobranca.PrecoDiarioPlanoDiario = planoCobrancaAtualizado.PrecoDiarioPlanoDiario;
		planoCobranca.PrecoQuilometroPlanoDiario = planoCobrancaAtualizado.PrecoQuilometroPlanoDiario;
		planoCobranca.QuilometrosDisponiveisPlanoControlado = planoCobrancaAtualizado.QuilometrosDisponiveisPlanoControlado;
		planoCobranca.PrecoDiarioPlanoControlado = planoCobrancaAtualizado.PrecoDiarioPlanoControlado;
		planoCobranca.PrecoQuilometroExtrapoladoPlanoControlado = planoCobrancaAtualizado.PrecoQuilometroExtrapoladoPlanoControlado;
		planoCobranca.PrecoDiarioPlanoLivre = planoCobrancaAtualizado.PrecoDiarioPlanoLivre;

		repositoiroPlanoCobranca.Editar(planoCobranca);

		return Result.Ok(planoCobranca);
	}

	public Result<PlanoCobranca> Excluir(int planoCobrancaId)
	{
		var planoCobranca = repositoiroPlanoCobranca.SelecionarPorId(planoCobrancaId);

		if (planoCobranca is null)
			return Result.Fail("O plano de cobrança não foi encontrado!");

		repositoiroPlanoCobranca.Excluir(planoCobranca);

		return Result.Ok(planoCobranca);
	}

	public Result<PlanoCobranca> SelecionarPorId(int planoCobrancaId)
	{
		var planoCobranca = repositoiroPlanoCobranca.SelecionarPorId(planoCobrancaId);

		if (planoCobranca is null)
			return Result.Fail("O plano de cobrança não foi encontrado!");

		return Result.Ok(planoCobranca);
	}

	public Result<List<PlanoCobranca>> SelecionarTodos()
	{
		var planosCobranca = repositoiroPlanoCobranca.SelecionarTodos();

		return Result.Ok(planosCobranca);
	}
}
