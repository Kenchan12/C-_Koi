using Blazored.LocalStorage;
using Blazored.Toast;
using KoiFishManager.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace KoiFishManager.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            _ = builder.Services.AddBlazoredToast();
            _ = builder.Services.AddTransient<IPondService, PondAPIService>();
            _ = builder.Services.AddBlazoredLocalStorage();
            _ = builder.Services.AddAuthorizationCore();
            _ = builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            _ = builder.Services.AddScoped<IAuthService, AuthService>();
            _ = builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["BackendApiUrl"])
            });

            await builder.Build().RunAsync();
        }
    }
}
