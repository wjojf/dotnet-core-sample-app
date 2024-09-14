using SampleRestAPI.infrastructure;

var builder = WebApplication.CreateBuilder(args);

ApplicationBundle.RegisterServices(builder);

var app = builder.Build();

ApplicationBundle.Configure(app);

app.Run();

