using PagueiBaratoApi.Api.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddApplications();
builder.Services.AddCore();
builder.Services.AddRepositories();
builder.Services.AddPasswordHasher();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();
app.Run();
