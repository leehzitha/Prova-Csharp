using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using prova.Models;
using prova.Services.Passeios;

namespace prova.UseCases.Passeios.EditPasseio;

public class EditPasseioUseCase(
    ProvaDbContext ctx,
    IPasseioService passeioService
)
{
    public async Task<Result<EditPasseioResponse>> Do(EditPasseioPayload payload)
    {
        var passeio = await passeioService.GetPasseio(payload.PasseioID);

        if (passeio is null)
            return Result<EditPasseioResponse>.Fail("Passeio not found");

        var ponto = await ctx.Pontos.FirstOrDefaultAsync(p => p.ID == payload.PasseioID);

        if (ponto is null)
            return Result<EditPasseioResponse>.Fail("Ponto not found!");

        passeio.Pontos.Add(ponto);
        await ctx.SaveChangesAsync();

        return Result<EditPasseioResponse>.Success(new());
        

    }
}