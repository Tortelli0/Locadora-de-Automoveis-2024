using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Aplicacao.Serviços;

public class ServicoGrupoAutomoveis
{
    private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

    public ServicoGrupoAutomoveis(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
    {
        this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
    }

    public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
    {
        repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

        return Result.Ok(grupoAutomoveis);
    }

    public Result<GrupoAutomoveis> Editar(GrupoAutomoveis grupoAutomoveisAtualizado)
    {
        var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisAtualizado.Id);

        if (grupoAutomoveis is null)
            return Result.Fail("O Grupo de Automoveis não foi encontrado!");

        grupoAutomoveis.Nome = grupoAutomoveisAtualizado.Nome;

        repositorioGrupoAutomoveis.Editar(grupoAutomoveis);

        return Result.Ok(grupoAutomoveis);
    }

    public Result Excluir(int grupoAutomoveisId)
    {
        var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);

        if (grupoAutomoveis is null)
            return Result.Fail("O Grupo de Automoveis não foi encontrado!");

        repositorioGrupoAutomoveis.Excluir(grupoAutomoveis);

        return Result.Ok();
    }

    public Result<GrupoAutomoveis> SelecionarPorId(int grupoAutomoveisId)
    {
        var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);

        if (grupoAutomoveis is null)
            return Result.Fail("O Grupo de Automoveis não foi encontrado!");

        return Result.Ok(grupoAutomoveis);
    }

    public Result<List<GrupoAutomoveis>> SelecionarTodos(int empresaId)
    {
        var gruposAutomoveis = repositorioGrupoAutomoveis.Filtrar(g => g.EmpresaId == empresaId);

        return Result.Ok(gruposAutomoveis);
    }
}
