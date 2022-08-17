using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Aula03_AgendaFoneApi.Requests;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula03_AgendaFoneApi.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private const string connectionString =
        @"Server=WINMACDELL-PRFO\SQLEXPRESS;Database=AgendaDb;Encrypt=False;Trusted_Connection=True;";

    public int Adicionar(PessoaRequest pessoa)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("INSERT INTO TbPessoa (nome) VALUES (@nome)", 
            new { nome = pessoa.Nome });
    }

    public int Alterar(PessoaRequest pessoa)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute(
            "UPDATE TbPessoa SET nome = @nome WHERE id = @id",
            new { nome = pessoa.Nome, id = pessoa.Id });
    }

    public int Apagar(int id)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("DELETE FROM TbPessoa WHERE id = @id",
            new { id = id });
    }

    public IEnumerable<Pessoa> BuscarPessoas()
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Query<Pessoa>("SELECT * FROM TbPessoa");
    }

    public Pessoa? BuscarPorId(int id)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.QueryFirstOrDefault<Pessoa>(
            "SELECT * FROM TbPessoa WHERE id = @id",
            new { id = id });
    }
}