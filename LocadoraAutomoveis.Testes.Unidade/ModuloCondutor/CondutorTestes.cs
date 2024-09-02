using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.Testes.Unidade.ModuloCondutor;

[TestClass]
[TestCategory("Unidade")]
public class CondutorTestes
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var condutor = new Condutor(clienteId: 1, clienteCondutor: true, nome: "Jose", email: "jose@gmail.com",
            telefone: "(49) 99999-9999", cpf: "000.000.000-99", cnh: "12309856743",
            validadeCnh: DateTime.Today.AddYears(1));

        var erros = condutor.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var condutor = new Condutor(clienteId: 1, clienteCondutor: true, nome: "", email: "jose@gmail.com",
            telefone: "(49) 99999-9999", cpf: "000.000.000-99", cnh: "12309856743",
            validadeCnh: DateTime.Today.AddYears(1));

        var erros = condutor.Validar();

        List<string> errosEsperados = new List<string>
        {
            "O nome é obrigatório"
        };

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}
