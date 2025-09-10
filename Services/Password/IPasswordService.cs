namespace prova.Services.Password;

public interface IPasswordService
{
    Task<bool> Compare(string password, string username);
}