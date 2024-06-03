using System.Net;
using System.Text.Json.Serialization;
using Erotion.API.Infrastructure.Database.Configurations;
using Erotion.API.Infrastructure.Database.Initializers;
using Erotion.API.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Settings.CorsNamePolicy,
        policy =>
        {
            policy
            .WithOrigins("https://localhost:7261", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers().AddJsonOptions(
options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 7261;
});

// Add databases
builder.Services.AddDatabaseErotionContext(builder.Configuration);

// Add mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();


var appservices = app.Services
        .CreateScope()
        .ServiceProvider;

await appservices.InitializeErotionContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(Settings.CorsNamePolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
