using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using prova.UseCases.Passeios.CreatePasseio;
using prova.UseCases.Passeios.EditPasseio;
using prova.UseCases.Passeios.GetPasseios;

namespace prova.Endpoints;

public static class PasseioEndpoints
{
    public static void ConfigurePasseioEndpoints(this WebApplication app)
    {
        app.MapGet("passeio", async (
            [FromBody] GetPasseiosPayload payload,
            [FromServices] GetPasseiosUseCase useCase) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        });

        app.MapPut("passeio/edit", async (
            HttpContext http,
            [FromBody] EditPasseioPayload payload,
            [FromServices] EditPasseioUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return Results.Unauthorized();

            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();

        }).RequireAuthorization();

        app.MapPost("passeio/create", async (
            HttpContext http,
            [FromBody] CreatePasseioPayload payload,
            [FromServices] CreatePasseioUseCase useCase) =>
            {
                var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);

                if (claim is null)
                    return Results.Unauthorized();
                    
                var result = await useCase.Do(payload);

                if (!result.IsSuccess)
                    return Results.BadRequest(result.Reason);

                return Results.Ok();
                    
            }).RequireAuthorization();


    }
}
