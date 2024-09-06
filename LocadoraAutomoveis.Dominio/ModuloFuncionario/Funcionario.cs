using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutenticacao;

namespace LocadoraAutomoveis.Dominio.ModuloFuncionario;

public class Funcionario : EntidadeBase
{
    public int UsuarioId { get; set; }

    public int EmpresaId { get; set; }
    public Usuario? Empresa { get; set; }

    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public DateTime Admissao { get; set; }
    public decimal Salario { get; set; }

    protected Funcionario() { }

    public Funcionario(string nomeCompleto, DateTime admissao, decimal salario, string email, int empresaId)
    {
        NomeCompleto = nomeCompleto;
        Admissao = admissao;
        Salario = salario;
        Email = email;
        EmpresaId = empresaId;
    }

    public override List<string> Validar()
    {
        return [];
    }
}