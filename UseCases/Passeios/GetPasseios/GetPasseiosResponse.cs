using prova.Models;

namespace prova.UseCases.Passeios.GetPasseios;

public record GetPasseiosResponse (
    IEnumerable<PasseioData> Passeios
);