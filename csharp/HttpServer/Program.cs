using HttpServer;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/users/sync", () =>
{
    var users = new User[1000];

    for (var x = 0; x < 1000; x++)
    {
        users[x] = new User
        {
            Id = x,
            FirstName = "FirstName" + x,
            LastName = "LastName" + x,
        };
    }

    return users;
});

app.MapGet("/users/async", () =>
{
    async IAsyncEnumerable<User> StreamUsersAsync()
    {
        for (var x = 0; x < 1000; x++)
        {
            yield return new User
            {
                Id = x,
                FirstName = "FirstName" + x,
                LastName = "LastName" + x,
            };
        }
    }

    return StreamUsersAsync();
});

app.Run();