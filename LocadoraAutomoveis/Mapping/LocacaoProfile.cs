using AutoMapper;
using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxa;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class LocacaoProfile : Profile
{
    public LocacaoProfile()
    {
        CreateMap<InserirLocacaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        CreateMap<RealizarDevolucaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        CreateMap<Locacao, InserirLocacaoViewModel>()
            .ForMember(l => l.Automoveis, opt => opt.MapFrom(src => src.Automovel!.Modelo))
            .ForMember(l => l.Condutores, opt => opt.MapFrom(src => src.Condutor!.Nome))
            .ForMember(l => l.TipoPlano, opt => opt.MapFrom(src => src.TipoPlano.ToString()));

        CreateMap<Locacao, RealizarDevolucaoViewModel>()
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Automoveis, opt => opt.MapFrom<AutomoveisValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

        // Check-in

        CreateMap<Locacao, ConfirmarAberturaLocacaoViewModel>()
            .ForMember(l => l.ValorParcial, opt => opt.MapFrom<ValorParcialValueResolver>())
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Automoveis, opt => opt.MapFrom<AutomoveisValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

        CreateMap<ConfirmarAberturaLocacaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        // Check-out
        CreateMap<Locacao, ConfirmarDevolucaoLocacaoViewModel>()
            .ForMember(vm => vm.ValorTotal, opt => opt.MapFrom<ValorTotalValueResolver>())
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Automoveis, opt => opt.MapFrom<AutomoveisValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

        CreateMap<ConfirmarDevolucaoLocacaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());
    }
}

public class ValorTotalValueResolver : IValueResolver<Locacao, ConfirmarDevolucaoLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoPlanoCobranca servicoPlano;

    public ValorTotalValueResolver(ServicoAutomovel servicoAutomovel, ServicoPlanoCobranca servicoPlano)
    {
        this.servicoAutomovel = servicoAutomovel;
        this.servicoPlano = servicoPlano;
    }

    public decimal Resolve(Locacao source, ConfirmarDevolucaoLocacaoViewModel destination, decimal destMember,
        ResolutionContext context)
    {
        var automovel = servicoAutomovel.SelecionarPorId(source.AutomovelId).Value;

        var planoSelecionado = servicoPlano.SelecionarPorIdGrupoAutomoveis(automovel.GrupoAutomoveisId).Value;

        return source.CalcularValorTotal(planoSelecionado);
    }
}

public class ValorParcialValueResolver : IValueResolver<Locacao, ConfirmarAberturaLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoPlanoCobranca servicoPlano;

    public ValorParcialValueResolver(ServicoAutomovel servicoAutomovel, ServicoPlanoCobranca servicoPlano)
    {
        this.servicoAutomovel = servicoAutomovel;
        this.servicoPlano = servicoPlano;
    }

    public decimal Resolve(Locacao source, ConfirmarAberturaLocacaoViewModel destination, decimal destMember,
        ResolutionContext context)
    {
        var automovel = servicoAutomovel.SelecionarPorId(source.AutomovelId).Value;

        var planoSelecionado = servicoPlano.SelecionarPorIdGrupoAutomoveis(automovel.GrupoAutomoveisId).Value;

        return source.CalcularValorParcial(planoSelecionado);
    }
}