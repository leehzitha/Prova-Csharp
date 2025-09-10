using prova.Models;

namespace prova.Services.Passeios;

public interface IPasseioService
{
    Task<int> CreatePasseio(Passeio passeio);
    Task<Passeio?> GetPasseio(int ID);
    
}