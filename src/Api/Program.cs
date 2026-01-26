using PagueiBaratoApi.Api.Setup;
using PagueiBaratoApi.Domain.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Secrets>(builder.Configuration);

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
