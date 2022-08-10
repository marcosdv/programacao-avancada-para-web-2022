using Aula03_AgendaFoneApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
//leonardo
namespace Aula03_AgendaFoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    private const string connectionString =
        @"Server=WINMACDELL-PRFO\SQLEXPRESS;Database=AgendaDb;Encrypt=False;Trusted_Connection=True;";

    [HttpGet]
    public IList<Operadora> BuscarTodos()
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

    [HttpPost("{nome}")]
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

    [HttpPut]
    public int Alterar([FromBody] Operadora operadora)
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

    [HttpDelete("{id}")]
    public IActionResult Apagar(int id)
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

            return Ok(command.ExecuteNonQuery());
            //return StatusCode(200, command.ExecuteNonQuery());
        }
        catch (Exception ex)
        {
            //return BadRequest(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
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

            return Ok(operadora);
        }

        return NoContent();
    }
}