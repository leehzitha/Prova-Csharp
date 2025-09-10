using Microsoft.AspNetCore.Mvc;
using prova.UseCases.Users;

namespace prova.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapGet("login", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        });
    }
}
