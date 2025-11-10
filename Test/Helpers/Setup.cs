using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;
using Test.Mocks;

namespace Test.Helpers;

public class Setup
{
    public const string PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();
        Setup.http = http.WithWebHostBuilder(builder =>
        {
            builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAdministradorServico, AdministradorServicoMock>();

                /*//Para testar com conexão diferente, descomente o código abaixo e comente o código acima
                var conexao = "Server=localhost;Port=3306;Database=minimal_api_test;User Id=root;Password=root;";
                services.AddDbContext<DbContexto>(options =>
                {
                    options.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
                });*/
            });

        });

        Setup.client = Setup.http.CreateClient();
    }

    public static void ClassCleanup()
    {
        // Setup.client.Dispose();
        Setup.http.Dispose();
    }

}