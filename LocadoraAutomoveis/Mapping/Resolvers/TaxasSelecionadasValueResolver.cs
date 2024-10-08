﻿using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class TaxasSelecionadasValueResolver : IValueResolver<FormularioLocacaoViewModel, Locacao, List<Taxa>>
{
    private readonly IRepositorioTaxa repositorioTaxa;

    public TaxasSelecionadasValueResolver(IRepositorioTaxa repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public List<Taxa> Resolve(FormularioLocacaoViewModel source, Locacao destination, List<Taxa> destMember, ResolutionContext context)
    {
        var idsTaxasSelecionadas = source.TaxasSelecionadas.ToList();

        return repositorioTaxa.SelecionarMuitos(idsTaxasSelecionadas);
    }
}