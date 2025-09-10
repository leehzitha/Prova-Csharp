namespace prova.Models;

public class PasseioData
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<string> PointNames { get; set; } = [];
    public string CreatorName { get; set; }
}
