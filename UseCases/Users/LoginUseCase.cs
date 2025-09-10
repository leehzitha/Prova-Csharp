using prova.Services.JWT;
using prova.Services.Password;
using prova.Services.Profile;

namespace prova.UseCases.Users;

public class LoginUseCase(
    IProfileService profilesService,
    IJWTService jWTService,
    IPasswordService passwordService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profilesService.GetProfileByUsername(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        var passwordMatch = await passwordService.Compare(payload.Login, payload.Password);

        if (!passwordMatch)
            return Result<LoginResponse>.Fail("Wrong Password!");

        var jwt = jWTService.CreateToken(
            new (
            user.ID,
            user.Username
        ));
        
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}