namespace Aula03_AgendaFoneApi.Models;

public class Operadora : Entidade
{
    public Operadora(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public string Nome { get; private set; }
}