using MeusLivros.Domain.Commands;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class EditoraInserirCommandTests
{
    [TestMethod]
    public void DadoUmComandoInvalidoDeveRetornarInvalida()
    {
        var command = new EditoraInserirCommand("");
        command.Validar();

        Assert.IsTrue(command.isInvalida);
        Assert.IsTrue(command.Notificacoes.Any());
    }

    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarValida()
    {
        var command = new EditoraInserirCommand() { Nome = "Nome" };
        command.Validar();

        Assert.IsTrue(command.isValida);
    }
}