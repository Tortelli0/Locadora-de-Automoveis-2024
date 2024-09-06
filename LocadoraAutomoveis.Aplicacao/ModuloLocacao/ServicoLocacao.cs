using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.Dominio.ModuloLocacao;

namespace LocadoraAutomoveis.Aplicacao.ModuloLocacao;

public class ServicoLocacao
{
    private readonly IRepositorioLocacao repositorioLocacao;
    private readonly IRepositorioConfiguracaoCombustivel repositorioCombustivel;
    private readonly IRepositorioAutomoveis repositorioAutomovel;

    public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IRepositorioConfiguracaoCombustivel repositorioCombustivel, IRepositorioAutomoveis repositorioAutomovel)
    {
        this.repositorioLocacao = repositorioLocacao;
        this.repositorioCombustivel = repositorioCombustivel;
        this.repositorioAutomovel = repositorioAutomovel;
    }

    public Result<Locacao> Inserir(Locacao locacao)
    {
        var config = repositorioCombustivel.ObterConfiguracao(locacao.EmpresaId);

        if (config is null)
            return Result.Fail("Não foi possível obter a configuração de valores de combustíveis.");

        locacao.ConfiguracaoCombustivelId = config.Id;

        var erros = locacao.Validar();

        if (erros.Count > 0)
            return Result.Fail(erros);

        AbrirLocacao(locacao);

        repositorioLocacao.Inserir(locacao);

        return Result.Ok(locacao);
    }

    public Result<Locacao> RealizarDevolucao(Locacao locacaoParaDevolucao)
    {
        if (locacaoParaDevolucao.DataDevolucao is not null)
            return Result.Fail("A devolução já foi realizada!");

        FecharLocacao(locacaoParaDevolucao);

        repositorioLocacao.Editar(locacaoParaDevolucao);

        return Result.Ok(locacaoParaDevolucao);
    }

    public Result<Locacao> Editar(Locacao locacaoAtualizada)
    {
        var locacao = repositorioLocacao.SelecionarPorId(locacaoAtualizada.Id);

        if (locacao is null)
            return Result.Fail("A locação não foi encontrada!");

        if (locacao.DataDevolucao is not null)
            return Result.Fail("A devolução já foi realizada!");

        var erros = locacaoAtualizada.Validar();

        if (erros.Count > 0)
            return Result.Fail(erros);

        locacao.Automovel!.Desocupar();

        locacao.AutomovelId = locacaoAtualizada.AutomovelId;
        locacao.CondutorId = locacaoAtualizada.CondutorId;
        locacao.ConfiguracaoCombustivelId = locacaoAtualizada.ConfiguracaoCombustivelId;
        locacao.TipoPlano = locacaoAtualizada.TipoPlano;
        locacao.MarcadorCombustivel = locacaoAtualizada.MarcadorCombustivel;
        locacao.QuilometragemPercorrida = locacaoAtualizada.QuilometragemPercorrida;
        locacao.DataLocacao = locacaoAtualizada.DataLocacao;
        locacao.DevolucaoPrevista = locacaoAtualizada.DevolucaoPrevista;
        locacao.DataDevolucao = locacaoAtualizada.DataDevolucao;
        locacao.TaxasSelecionadas = locacaoAtualizada.TaxasSelecionadas;

        repositorioLocacao.Editar(locacao);

        return Result.Ok(locacao);
    }

    public Result<Locacao> Excluir(int locacaoId)
    {
        var locacao = repositorioLocacao.SelecionarPorId(locacaoId);

        if (locacao is null)
            return Result.Fail("A locação não foi encontrada!");

        repositorioLocacao.Excluir(locacao);

        return Result.Ok(locacao);
    }

    public Result<Locacao> SelecionarPorId(int locacaoId)
    {
        var locacao = repositorioLocacao.SelecionarPorId(locacaoId);

        if (locacao is null)
            return Result.Fail("A locação não foi encontrada!");

        return Result.Ok(locacao);
    }

    public Result<List<Locacao>> SelecionarTodos(int empresaId)
    {
        var locacoes = repositorioLocacao.Filtrar(g => g.EmpresaId == empresaId);

        return Result.Ok(locacoes);
    }

    private void AbrirLocacao(Locacao locacao)
    {
        var automovelSelecionado = repositorioAutomovel.SelecionarPorId(locacao.AutomovelId);

        locacao.Automovel = automovelSelecionado;

        locacao.Abrir();

        repositorioAutomovel.Editar(locacao.Automovel!);
    }


    private void FecharLocacao(Locacao locacao)
    {
        var automovelSelecionado = repositorioAutomovel.SelecionarPorId(locacao.AutomovelId);

        locacao.Automovel = automovelSelecionado;

        locacao.RealizarDevolucao();

        repositorioAutomovel.Editar(locacao.Automovel!);
    }
}