namespace prova.Models;

public class Ponto
{
    public int ID { get; set; }
    public string Title { get; set; }

    public ICollection<Passeio> Passeios { get; set; } = [];
}