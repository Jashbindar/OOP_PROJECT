using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


namespace mudblazor2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); 
            //added backend API call port
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7012") });
            builder.Services.AddSingleton<Homework2Library.UserDetail>();
            builder.Services.AddSingleton<DatabaseLogic.DatabaseAccountrix>();
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}
