

using Microsoft.EntityFrameworkCore;
using prova;
using prova.Models;
using prova.Services.Password;

public class EFPasswordService(ProvaDbContext ctx) : IPasswordService
{
    public async Task<bool> Compare(string password, string username)
    {
        var user = await ctx.Users.FirstOrDefaultAsync(
            u => u.Username == username || u.Password == password
        );

        if (user is null)
            return false;
        return true;
    }
}