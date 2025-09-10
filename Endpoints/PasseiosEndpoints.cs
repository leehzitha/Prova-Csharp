using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using prova.UseCases.Passeios.EditPasseio;
using prova.UseCases.Passeios.GetPasseios;

namespace prova.Endpoints;

public static class PasseioEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapGet("passeios", async (
            [FromBody] GetPasseiosPayload payload,
            [FromServices] GetPasseiosUseCase useCase) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        });

        app.MapGet("passeio/edit", async (
            HttpContext http,
            [FromBody] EditPasseioPayload payload,
            [FromServices] EditPasseioUseCase useCase) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        });
    }
}
