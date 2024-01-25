using FluentMigrator.Runner;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Infraestrutura.Extensoes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepositorio, RepositorioLinqToDb>();

var construtor = CriaHostBuilder();
using var build = construtor.Build();
var servicesProvider = build.Services;

UpdateDataBase(servicesProvider);

static void UpdateDataBase(IServiceProvider servicesProvider)
{
    var runner = servicesProvider.GetRequiredService<IMigrationRunner>();

    runner.MigrateUp();
}

static IHostBuilder CriaHostBuilder()
{
    return Host.CreateDefaultBuilder()
        .ConfigureContainer<IServiceCollection>((context, services) =>
        {
            services.ExecutarMigracoes();
        });
}

var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
),

    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings = { [".properties"] = "application/x-msdownload" }
    }
});
app.UseAuthorization();

app.MapControllers();

app.Run();