using prova.Models;
using prova.Services.Passeios;
using prova.Services.Profile;

namespace prova.UseCases.Passeios.CreatePasseio;

public class CreatePasseioUseCase(
    IPasseioService passeioService,
    IProfileService profileService
)
{
    public async Task<Result<CreatePasseioResponse>> Do(CreatePasseioPayload payload)
    {
        var creator = await profileService.GetProfile(payload.CreatorID);

        if (creator is null)
            return Result<CreatePasseioResponse>.Fail("User doesn't exist.");

        var passeio = new Passeio
        {
            Title = payload.Title,
            Description = payload.Description,
            CreatorID = payload.CreatorID,
            User = creator
        };

        await passeioService.CreatePasseio(passeio);

        return Result<CreatePasseioResponse>.Success(new());
    }
}
