using Athena.Web;
using Athena.Web.Services;
using Athena.Web.Services.ServicesImplementation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Athena.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient 
            {
                    BaseAddress = new Uri("https://localhost:7036/") 
            });

        /*
         builder.Services.AddScoped(sp => new HttpClient 
        {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseApiUrl")) 
        });*/
        
            builder.Services.AddMudServices();
            builder.Services.AddScoped<ILinhaNegocioServices, LinhaNegocioServices>();
            builder.Services.AddScoped<IClienteServices, ClienteServices>();
            builder.Services.AddScoped<IDepartamentoServices, DepartamentoServices>();
            builder.Services.AddScoped<IFuncaoServices, FuncaoServices>();            
            builder.Services.AddScoped<ITipoDadosListasServices, TipoDadosListasServices>();
            builder.Services.AddScoped<IDadosListasServices, DadosListasServices>();
            builder.Services.AddScoped<IPreAtendimentoPlantaoServices, PreAtendimentoPlantaoServices>();
            builder.Services.AddScoped<IAtendimentoPlantaoServices, AtendimentoPlantaoServices>();
            builder.Services.AddScoped<IPainelGeralBigNumbersServices, PainelGeralBigNumbersServices>();

            await builder.Build().RunAsync();
        }
    }
}