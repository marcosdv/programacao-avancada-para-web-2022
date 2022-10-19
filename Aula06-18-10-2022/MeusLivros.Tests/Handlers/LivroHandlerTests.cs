using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Handlers;

[TestClass]
public class LivroHandlerTests
{
    private readonly ILivroRepository _repository;
    private readonly LivroHandler _handler;

    public LivroHandlerTests()
    {
        _repository = new MockLivroRepository();
        _handler = new LivroHandler(_repository);
    }

    #region Inserir Testes

    [TestMethod]
    public void DadoUmComandoInserirValidoRetornaSucessoTrue()
    {
        var command = new LivroInserirCommand("Nome", 1);

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoInserirInvalidoRetornaSucessoFalse()
    {
        var command = new LivroInserirCommand();

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    #endregion

    #region Alterar Testes

    [TestMethod]
    public void DadoUmComandoAlterarValidoDeveRetornarSucessoTrue()
    {
        var command = new LivroAlterarCommand(1, "Nome", 1);

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarInvalidoDeveRetornarSucessoFalse()
    {
        var command = new LivroAlterarCommand(0, "", 0);

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarValidoMasComLivroInexistenteDeveRetornarSucessoFalse()
    {
        var command = new LivroAlterarCommand(9, "Nome", 1);

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    #endregion

    #region Excluir Testes

    [TestMethod]
    public void DadoUmComandoExcluirValidoDeveRetornarSucessoTrue()
    {
        var command = new LivroExcluirCommand(1);

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirInvalidoDeveRetornarSucessoFalse()
    {
        var command = new LivroExcluirCommand();

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirValidoMasComLivroInexistenteDeveRetornarSucessoFalse()
    {
        var command = new LivroExcluirCommand(9);

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    #endregion
}