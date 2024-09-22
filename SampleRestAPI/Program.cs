using SampleRestAPI.infrastructure.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Prepare();

var app = builder.Build();

app.Configure();

app.Run();

