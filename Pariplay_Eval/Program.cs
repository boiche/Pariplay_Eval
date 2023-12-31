using Microsoft.EntityFrameworkCore;
using Pariplay_Eval.Data;
using Pariplay_Eval.Middlewares;
using Pariplay_Eval.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITeamsService, TeamsService>();
builder.Services.AddScoped<IMatchesService, MatchesService>();
builder.Services.AddScoped<ILeaguesService, LeaguesService>();
builder.Services.AddDbContext<EvalDbContext>(x => 
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
