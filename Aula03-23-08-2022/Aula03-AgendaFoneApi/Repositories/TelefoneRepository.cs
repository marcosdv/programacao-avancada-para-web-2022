using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Aula03_AgendaFoneApi.Requests;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula03_AgendaFoneApi.Repositories;

public class TelefoneRepository : ITelefoneRepository
{
    private const string connectionString =
        @"Server=WINMACDELL-PRFO\SQLEXPRESS;Database=AgendaDb;Encrypt=False;Trusted_Connection=True;";

    public int Adicionar(TelefoneRequest telefone)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute(@"
            INSERT INTO TbTelefone (numero, operadoraId, pessoaId)
                 VALUES (@numero, @operadoraId, @pessoaId)",
            new {
                numero = telefone.Numero,
                operadoraId = telefone.Operadora,
                pessoaId = telefone.Pessoa
            });
    }

    public int Alterar(TelefoneRequest telefone)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute(@"
            UPDATE TbTelefone SET
                numero = @numero,
                operadoraId = @operadoraId,
                pessoaId = @pessoaId
            WHERE id = @id",
            new {
                numero = telefone.Numero,
                operadoraId = telefone.Operadora,
                pessoaId = telefone.Pessoa,
                id = telefone.Id
            }
        );
    }

    public int Apagar(int id)
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Execute("DELETE FROM TbTelefone WHERE id = @id",
            new { id = id });
    }

    public Telefone? BuscarPorId(int id)
    {
        using var connection = new SqlConnection(connectionString);

        var fones = connection.Query<Telefone, Operadora, Telefone>(@"
            SELECT * FROM TbTelefone T
            INNER JOIN TbOperadora O ON T.operadoraId = O.id
            WHERE T.id = @id",
            (telefone, operadora) => {
                telefone.adicionarOperadora(operadora);
                return telefone;
            },
            new { id = id });

        return fones.FirstOrDefault();
    }

    public IEnumerable<Telefone> BuscarTodos()
    {
        using var connection = new SqlConnection(connectionString);

        return connection.Query<Telefone, Operadora, Telefone>(@"
            SELECT * FROM TbTelefone T
            INNER JOIN TbOperadora O ON T.operadoraId = O.id",
            (telefone, operadora) => {
                telefone.adicionarOperadora(operadora);
                return telefone;
            });
    }
}