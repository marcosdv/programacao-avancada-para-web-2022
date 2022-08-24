using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace Aula03_AgendaFoneApi.Repositories;

public class OperadoraRepository : IOperadoraRepository
{
    private const string connectionString =
        @"Server=WINMACDELL-PRFO\SQLEXPRESS;Database=AgendaDb;Encrypt=False;Trusted_Connection=True;";

    #region Buscas

    public IList<Operadora> BuscarOperadoras()
    {
        var operadoras = new List<Operadora>();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT * FROM TbOperadora";

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operadora =
                new Operadora(reader.GetInt32(0), reader.GetString(1));

            operadoras.Add(operadora);
        }

        return operadoras;
    }

    public Operadora? BuscarPorId(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT * FROM TbOperadora WHERE id = @id";
        command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operadora =
                new Operadora(reader.GetInt32(0), reader.GetString(1));

            return operadora;
        }

        return null;
    }

    #endregion

    public int Adicionar(string nome)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "INSERT INTO TbOperadora (nome) VALUES (@nome)";
        command.Parameters
            .Add("@nome", System.Data.SqlDbType.VarChar).Value = nome;

        return command.ExecuteNonQuery();
    }

    public int Alterar(Operadora operadora)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "UPDATE TbOperadora SET nome = @nome WHERE id = @id";
        command.Parameters
            .Add("@nome", System.Data.SqlDbType.VarChar).Value = operadora.Nome;
        command.Parameters
            .Add("@id", System.Data.SqlDbType.Int).Value = operadora.Id;

        return command.ExecuteNonQuery();
    }

    public int Apagar(int id)
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM TbOperadora WHERE id = @id";
            command.Parameters
                .Add("@id", System.Data.SqlDbType.Int).Value = id;

            return command.ExecuteNonQuery();
        }
        catch
        {
            return 0;
        }
    }
}