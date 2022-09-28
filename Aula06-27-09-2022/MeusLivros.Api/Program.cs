using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using MeusLivros.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Injecao de dependencias - DI
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("connectionString")
    )
);
builder.Services.AddTransient<IEditoraRepository, EditoraRepository>();
builder.Services.AddTransient<ILivroRepository, LivroRepository>();
builder.Services.AddTransient<EditoraHandler, EditoraHandler>();
builder.Services.AddTransient<LivroHandler, LivroHandler>();


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => 
    x.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();