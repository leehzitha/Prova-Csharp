using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using prova.Models;
using prova.Services.Passeios;
using prova.Services.Profile;
using prova.UseCases.Passeios.EditPasseio;

namespace prova.UseCases.Passeios.GetPasseios;

public class GetPasseiosUseCase(
    IPasseioService passeioService,
    IProfileService profileService,
    ProvaDbContext ctx
)
{
    public async Task<Result<GetPasseiosResponse>> Do(GetPasseiosPayload payload)
    {
        var passeio = await passeioService.GetPasseio(payload.ID);

        if (passeio is null)
            return Result<GetPasseiosResponse>.Fail("Passeio not found");


        var creator = await profileService.GetProfile(passeio.CreatorID);

        // var pontoNames = await ctx.Passeios
        //     .Include(p => p.Pontos)
        //         .ThenInclude(po => po.Title)
        //     .Where(p => p.ID == passeio.ID)
        //     .ToListAsync();

        ICollection<string> titles = [];

        foreach (var a in passeio.Pontos)
            titles.Add(a.Title);

        var response = new PasseioData
        {
            Title = passeio.Title,
            CreatorName = creator.Username,
            PointNames = titles,
            Description = passeio.Description
        };

        return Result<GetPasseiosResponse>.Success(new GetPasseiosResponse(response));
    }
}