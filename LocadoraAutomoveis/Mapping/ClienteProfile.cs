﻿using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class ClienteProfile : Profile
{
	public ClienteProfile()
	{
		CreateMap<InserirClienteViewModel, Cliente>();
		CreateMap<EditarClienteViewModel, Cliente>();

		CreateMap<Cliente, ListarClienteViewModel>()
			.ForMember(
				dest => dest.TipoCadastro,
				opt => opt.MapFrom(x => x.TipoCadastro.ToString())
			);

		CreateMap<Cliente, DetalhesClienteViewModel>()
			.ForMember(
				dest => dest.TipoCadastro,
				opt => opt.MapFrom(x => x.TipoCadastro.ToString())
			);

		CreateMap<Cliente, EditarClienteViewModel>();
	}
}