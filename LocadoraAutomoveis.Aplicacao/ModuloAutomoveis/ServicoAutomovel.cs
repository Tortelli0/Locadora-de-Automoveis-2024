﻿using FluentResults;
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
		automovel.TipoCombustivelEnum = automovelAtualizado.TipoCombustivelEnum;
		automovel.CapacidadeLitros = automovelAtualizado.CapacidadeLitros;
		automovel.GrupoAutomoveisId = automovelAtualizado.GrupoAutomoveisId;

		repositorioAutomovel.Editar(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> Excluir(int automovelId)
	{
		var automovel = repositorioAutomovel.SelecionarPorId(automovelId);

		if (automovel is null)
			return Result.Fail("O automovel não foi encontrado!");

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

	public Result<List<Automovel>> SelecionarTodos(int empresaId)
	{
		var automoveis = repositorioAutomovel.Filtrar(g => g.EmpresaId == empresaId);

		return Result.Ok(automoveis);
	}
}
