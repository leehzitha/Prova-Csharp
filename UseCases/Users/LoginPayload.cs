using System.ComponentModel.DataAnnotations;

namespace prova.UseCases.Users;

public record LoginPayload (
    string Login,
    string Password

);