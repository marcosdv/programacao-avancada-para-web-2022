using MeusLivros.Domain.Commands;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class LivroAlterarCommandTests
{
    [DataTestMethod]
    [DataRow(1, "", 1)]
    [DataRow(1, "Nome", 0)]
    [DataRow(0, "Nome", 1)]
    [DataRow(0, "", 0)]
    public void DadoUmComandoInvalidoDeveRetornarClasseInvalida(
        int id, string nome, int editora)
    {
        var command = new LivroAlterarCommand(id, nome, editora);
        command.Validar();

        Assert.IsTrue(command.isInvalida);
    }

    [DataTestMethod]
    [DataRow(1, "Nome", 1)]
    [DataRow(2, "Outro Nome", 1)]
    public void DadoUmComandoValidoDeveRetornarClasseValida(
        int id, string nome, int editora)
    {
        var command = new LivroAlterarCommand(id, nome, editora);
        command.Validar();

        Assert.IsTrue(command.isValida);
    }
}