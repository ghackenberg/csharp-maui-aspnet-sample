using CustomApi.Handlers;

// Step 1: Create and configure builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<HttpExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Step 2: Create and configure app

var app = builder.Build();

app.MapControllers();
app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();