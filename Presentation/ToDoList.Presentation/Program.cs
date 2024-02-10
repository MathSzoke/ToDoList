var builder = WebApplication.CreateBuilder(args);

builder.BuilderArchitectures();

var app = builder.Build();

app.AppArchitectures();

app.Run();