using LocadoraAutomoveis.Dominio.ModuloAutenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.Compartilhado;

public abstract class EntidadeBase
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public Usuario? Empresa { get; set; }

    public abstract List<string> Validar();
}

