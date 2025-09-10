namespace prova.UseCases.Passeios.EditPasseio;

public record EditPasseioPayload (
    int PasseioID,
    int PontoID
);