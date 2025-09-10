using System.ComponentModel.DataAnnotations;

namespace prova.UseCases.Passeios.CreatePasseio;

public record CreatePasseioPayload
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }

    [Required]
    [MinLength(40)]
    [MaxLength(200)]
    public string Description { get; set; }

    [Required]
    public int CreatorID { get; set; }

}