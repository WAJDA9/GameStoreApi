using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.EndPoints;

public static class GamesEndPoint
{
    const string GetGameEndPoint = "GetGame";

    private static readonly List<GameDto> games = [
        new GameDto(1, "GTA V", "Action", 20.00m,"https://images.hdqwalls.com/wallpapers/grand-theft-auto-v-hd.jpg", new DateOnly(2013, 9, 17)),
    new GameDto(2, "FIFA 22", "Sports", 60.00m,"https://www.gamingthrill.com/wp-content/uploads/2021/09/FIFA-22-2.jpg", new DateOnly(2021, 10, 1)),
    new GameDto(3, "Cyberpunk 2077", "RPG", 40.00m,"https://th.bing.com/th/id/OIP.IF5Au6A6X1uKYDT-SZWP_AHaD4?rs=1&pid=ImgDetMain", new DateOnly(2020, 12, 10)),
    new GameDto(4, "The Witcher 3", "RPG", 30.00m,"https://th.bing.com/th/id/OIP.A3MZXwJXhVlLbNnp1LLk5gHaEo?rs=1&pid=ImgDetMain", new DateOnly(2015, 5, 19)),
    new GameDto(5, "FIFA 21", "Sports",50.00m,"https://th.bing.com/th/id/OIP.245xHfXucsFnU_Ux6hHjhgHaEK?rs=1&pid=ImgDetMain",  new DateOnly(2020, 10, 6)),
];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", () => games);

        // GET game by id
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(g => g.Id == id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }

            ).WithName(GetGameEndPoint);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            if (String.IsNullOrEmpty(newGame.Name))
            {
                return Results.BadRequest("Name is required");
            }
            GameDto game = new GameDto(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.Image,
                newGame.ReleaseDate
            );
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game);
        }).WithParameterValidation();

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(g => g.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.Image,
                updatedGame.ReleaseDate
            );
            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(g => g.Id == id);
            return Results.NoContent();
        });



        return group;
    }

}
