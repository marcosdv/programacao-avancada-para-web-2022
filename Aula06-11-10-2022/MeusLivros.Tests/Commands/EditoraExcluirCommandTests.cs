using MeusLivros.Domain.Commands;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class EditoraExcluirCommandTests
{
    [DataTestMethod]
    [DataRow(0, false)]
    [DataRow(1, true)]
    public void DadoUmComandoDeveValidarCorretamente(int id, bool valida)
    {
        var command = new EditoraExcluirCommand(id);
        command.Validar();

        Assert.AreEqual(valida, command.isValida);
    }
}