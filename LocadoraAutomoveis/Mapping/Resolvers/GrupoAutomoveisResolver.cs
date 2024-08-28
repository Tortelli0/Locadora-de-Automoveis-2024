using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraAutomoveis.WebApp.Mapping.Resolvers;

public class GrupoAutomoveisResolver : IValueResolver<object, object, IEnumerable<SelectListItem>?>
{
	private readonly IRepositorioGrupoAutomoveis repositorioGrupo;

	public GrupoAutomoveisResolver(IRepositorioGrupoAutomoveis repositorioGrupo)
	{
		this.repositorioGrupo = repositorioGrupo;
	}

	public IEnumerable<SelectListItem>? Resolve(object source, object destination, IEnumerable<SelectListItem>? destMember, ResolutionContext context)
	{
		return repositorioGrupo
			.SelecionarTodos()
			.Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
	}
}
