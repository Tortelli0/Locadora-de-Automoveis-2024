using System.ComponentModel.DataAnnotations;

namespace LocadoraAutomoveis.WebApp.Models;

public class InserirGrupoAutomoveisViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 caracteres")]
    public string Nome { get; set; }
}

public class EditarGrupoAutomoveisViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 caracteres")]
    public string Nome { get; set; }
}

public class ListarGrupoAutomoveisViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class DetalhesGrupoAutomoveisViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
}