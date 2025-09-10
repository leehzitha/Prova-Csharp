using Microsoft.EntityFrameworkCore;
using prova.Models;

namespace prova.Services.Passeios;

public class PasseioService(ProvaDbContext ctx) : IPasseioService
{
    public async Task<int> CreatePasseio(Passeio passeio)
    {
        ctx.Passeios.Add(passeio);
        await ctx.SaveChangesAsync();
        return passeio.ID;
    }

    public async Task<Passeio?> GetPasseio(int ID)
    {
        return await ctx.Passeios.FirstOrDefaultAsync(
            p => p.ID == ID
        );
    }
}