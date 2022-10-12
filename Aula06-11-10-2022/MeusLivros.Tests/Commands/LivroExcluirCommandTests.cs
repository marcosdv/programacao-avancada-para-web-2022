using MeusLivros.Domain.Commands;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class LivroExcluirCommandTests
{
    [DataTestMethod]
    [DataRow(1, true)]
    [DataRow(0, false)]
    public void DadoUmComandoDeveRetornarValidacaoCorreta(int id, bool valida)
    {
        var command = new LivroExcluirCommand(id);
        command.Validar();

        Assert.AreEqual(valida, command.isValida);
    }
}