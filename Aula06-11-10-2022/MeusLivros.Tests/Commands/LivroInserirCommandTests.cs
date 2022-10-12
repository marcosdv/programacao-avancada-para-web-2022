using MeusLivros.Domain.Commands;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class LivroInserirCommandTests
{
    [DataTestMethod]
    [DataRow("Nome", 1, true)]
    [DataRow("", 1, false)]
    [DataRow("Nome", 0, false)]
    [DataRow("", 0, false)]
    public void DadoUmComandoDeveRetornarValidacaoCorreta(
        string nome, int editora, bool valida)
    {
        var command = new LivroInserirCommand(nome, editora);
        command.Validar();

        Assert.AreEqual(valida, command.isValida);
    }
}