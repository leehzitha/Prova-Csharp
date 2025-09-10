using prova.Models;

namespace prova.Services.Profile;

public interface IProfileService
{
    Task<User?> GetProfile(string Username);
}