namespace Aula03_AgendaFoneApi.Models;

public class Telefone : Entidade
{
    public Telefone(int id, string numero, Operadora operadora)
    {
        Id = id;
        Numero = numero;
        this.operadora = operadora;
    }

    public string Numero { get; private set; }
    public Operadora operadora { get; private set; }
}