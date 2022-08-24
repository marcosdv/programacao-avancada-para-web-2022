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

    public IEnumerable<Pessoa> BuscarComFone()
    {
        using var connection = new SqlConnection(connectionString);

        var listaPessoas = new List<Pessoa>();

        var pessoas = connection.Query<Pessoa, Telefone, Pessoa>(
            @"SELECT * FROM TbPessoa P
              LEFT JOIN TbTelefone T ON T.pessoaId = P.id",
            (pessoa, telefone) =>
            {
                var pes = listaPessoas.Where(x => x.Id == pessoa.Id).FirstOrDefault();
                
                if (pes == null)
                {
                    pes = pessoa;
                    pes.adicionarTelefone(telefone);
                    listaPessoas.Add(pes);
                }
                else
                {
                    pes.adicionarTelefone(telefone);
                }

                return pessoa;
            });

        return listaPessoas;
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