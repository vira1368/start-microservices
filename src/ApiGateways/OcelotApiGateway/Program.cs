var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging((hostBuilderContext, loggingBuilder) =>
{
    loggingBuilder.AddConfiguration(hostBuilderContext.Configuration.GetSection("Logging"));
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
