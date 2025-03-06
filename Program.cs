var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddSwaggerGen();
    services.AddControllers();
    services.AddSingleton<ICosmosService<Movie>>(DatabaseInitializer.Initialize<Movie>(builder.Configuration).GetAwaiter().GetResult());
    services.AddSingleton<ICosmosService<Users>>(UsersDatabaseInitializer.Initialize<Users>(builder.Configuration).GetAwaiter().GetResult());
}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.MapControllers();
}

app.Run();