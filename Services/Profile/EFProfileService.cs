using Microsoft.EntityFrameworkCore;
using prova.Models;

namespace prova.Services.Profile;

public class ProfileService(ProvaDbContext ctx) : IProfileService
{
    public async Task<User?> GetProfile(string Username)
    {
        return await ctx.Users.FirstOrDefaultAsync(
            p => p.Username == Username
        );
    }
}