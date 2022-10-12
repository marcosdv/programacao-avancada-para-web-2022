using MeusLivros.Domain.Commands;

namespace MeusLivros.Tests.Commands;

[TestClass]
public class EditoraAlterarCommandTests
{
    [DataTestMethod]
    [DataRow(0, "", false, 2)]
    [DataRow(1, "", false, 1)]
    [DataRow(0, "Nome", false, 1)]
    [DataRow(1, "Nome", true, 0)]
    [DataRow(2, "Outro Nome", true, 0)]
    public void DadoUmComandoInvalidoRetornaClasseInvalida(
        int id, string nome, bool valida, int qtdErro)
    {
        var command = new EditoraAlterarCommand(id, nome);

        command.Validar();
        
        Assert.AreEqual(valida, command.isValida);
        Assert.AreEqual(qtdErro, command.Notificacoes.Count());
    }

    /*
    [TestMethod]
    public void DadoUmComandoComNomeInvalidoRetornaInvalidaUmaNotificacao()
    {
        var command = new EditoraAlterarCommand();
        command.Id = 10;

        command.Validar();

        Assert.IsTrue(command.isInvalida);
        Assert.AreEqual(1, command.Notificacoes.Count());
    }

    [TestMethod]
    public void DadoUmComandoComIdInvalidoRetornaInvalidaUmaNotificacao()
    {
        var command = new EditoraAlterarCommand();
        command.Nome = "Nome";

        command.Validar();

        Assert.IsTrue(command.isInvalida);
        Assert.AreEqual(1, command.Notificacoes.Count());
    }

    [TestMethod]
    public void DadoUmComandoComIdNomeInvalidoRetornaInvalidaDuasNotificacoes()
    {
        var command = new EditoraAlterarCommand();

        command.Validar();

        Assert.IsTrue(command.isInvalida);
        Assert.AreEqual(2, command.Notificacoes.Count());
    }

    [TestMethod]
    public void DadoUmComandoValidoRetornaValida()
    {
        var command = new EditoraAlterarCommand();
        command.Id = 1;
        command.Nome = "Nome";

        command.Validar();

        Assert.IsTrue(command.isValida);
        Assert.IsFalse(command.Notificacoes.Any());
    }
    */
}