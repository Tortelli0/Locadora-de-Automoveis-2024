using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Testes.Unidade.ModuloGrupoAutomoveis;

[TestClass]
[TestCategory("Unidade")]
public class GrupoAutomoveisTestes
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var grupo = new GrupoAutomoveis("SUV");

        var erros = grupo.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var grupo = new GrupoAutomoveis("");

        var erros = grupo.Validar();

        List<string> errosEsperados = ["O nome é obrigatório"];

        Assert.AreEqual(1, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}
