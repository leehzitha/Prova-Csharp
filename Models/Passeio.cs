namespace prova.Models;

public class Passeio
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int CreatorID { get; set; }
    public required User User { get; set; }

    public ICollection<Ponto> Pontos { get; set; } = [];

}