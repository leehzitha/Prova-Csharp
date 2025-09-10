namespace prova.Models;

public class Ponto
{
    public int ID { get; set; }
    public string Title { get; set; }

    ICollection<Passeio> Passeios { get; set; } = [];
}