using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;

namespace LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;

public class ServicoAutomovel
{
	private readonly IRepositorioAutomoveis repositorioAutomovel;

	public ServicoAutomovel(IRepositorioAutomoveis repositorioAutomovel)
	{
		this.repositorioAutomovel = repositorioAutomovel;
	}

	public Result<Automovel> Inserir(Automovel automovel)
	{
		repositorioAutomovel.Inserir(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> Editar(Automovel automovelAtualizado)
	{
		var automovel = repositorioAutomovel.SelecionarPorId(automovelAtualizado.Id);

		if (automovel is null)
			return Result.Fail("O automovel não foi encontrado!");

		automovel.Modelo = automovelAtualizado.Modelo;
		automovel.Marca = automovelAtualizado.Marca;
		automovel.Cor = automovelAtualizado.Cor;
		automovel.CapacidadeLitros = automovelAtualizado.CapacidadeLitros;
		automovel.TipoCombustivel = automovelAtualizado.TipoCombustivel;
		automovel.GrupoAutomoveis = automovelAtualizado.GrupoAutomoveis;

		repositorioAutomovel.Editar(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> Excluir(int automovelId)
	{
		var automovel = repositorioAutomovel.SelecionarPorId(automovelId);

		if (automovel is null)
			return Result.Fail("O Automoveil não foi encontrado!");

		repositorioAutomovel.Excluir(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> SelecionarPorId(int automovelId)
	{
		var automovel = repositorioAutomovel.SelecionarPorId(automovelId);

		if (automovel is null)
			return Result.Fail("O automovel não foi encontrado!");

		return Result.Ok(automovel);
	}

	public Result<List<Automovel>> SelecionarTodos()
	{
		var automoveis = repositorioAutomovel.SelecionarTodos();

		return Result.Ok(automoveis);
	}
}
