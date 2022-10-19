using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using MeusLivros.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
//Injecao de dependencias - DI

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
