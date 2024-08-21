﻿using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

public class GrupoAutomoveis : EntidadeBase
{
    public string Nome { get; set; }

    protected GrupoAutomoveis() { }

    public GrupoAutomoveis(string nome)
    {
        Nome = nome;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if(Nome.Length < 3)
            erros.Add("O nome é obrigatório");

        return erros;
    }
}
