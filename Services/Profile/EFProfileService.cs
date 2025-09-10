using Microsoft.EntityFrameworkCore;
using prova.Models;

namespace prova.Services.Profile;

public class ProfileService(ProvaDbContext ctx) : IProfileService
{
    public async Task<User?> GetProfile(int ID)
    {
        return await ctx.Users.FirstOrDefaultAsync(
            p => p.ID == ID
        );
    }

    public async Task<User?> GetProfileByUsername(string username)
    {
        return await ctx.Users.FirstOrDefaultAsync(
            p => p.Username == username
        );
    }
}