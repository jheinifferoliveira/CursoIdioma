using CursoIdioma.Domain.Interfaces.Repositories;
using CursoIdioma.Domain.Interfaces.Services;
using CursoIdioma.Domain.Services;
using CursoIdioma.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<ITurmaRepository, TurmaRepository>();
builder.Services.AddTransient<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddTransient<ITurmaService, TurmaService>();
builder.Services.AddTransient<IAlunoService, AlunoService>();
builder.Services.AddTransient<IMatriculaService, MatriculaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
