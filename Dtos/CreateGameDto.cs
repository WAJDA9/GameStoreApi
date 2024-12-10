namespace GameStore.Api.Dtos;

public record class CreateGameDto
(
    string Name,
    string Genre,
    decimal Price,
    string Image,
    DateOnly ReleaseDate

);
