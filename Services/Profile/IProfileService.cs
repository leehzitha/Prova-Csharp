using prova.Models;

namespace prova.Services.Profile;

public interface IProfileService
{
    Task<User?> GetProfile(int ID);
    Task<User?> GetProfileByUsername(string username);
}