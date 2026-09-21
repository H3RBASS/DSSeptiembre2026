using DSSeptiembre;
using DSSeptiembre.Shared.Configuration;
using DSSeptiembre.Shared.Interface;
using DSSeptiembre.Shared.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Supabase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//conexion a supabase

var supabaseOptions = builder.Configuration
    .GetSection("Supabase")
    .Get<SupabaseConfiguration>();

var supabaseUrl = supabaseOptions?.Url;
var supabaseKey = supabaseOptions?.Key;

if (string.IsNullOrWhiteSpace(supabaseUrl) || string.IsNullOrWhiteSpace(supabaseKey))
{
    throw new InvalidOperationException(
        "Falta la configuración de Supabase (Url y Key) en wwwroot/appsettings.json.");
}

var client = new Client(
    supabaseUrl,
    supabaseKey
);

await client.InitializeAsync();

builder.Services.AddSingleton(client);

//fin conexion a supabase

builder.Services.AddScoped<IRubroService, RubroService>();
builder.Services.AddScoped<ICatalogoService, CatalogoService>();
builder.Services.AddScoped<IClienteNaturalService, ClienteNaturalService>();

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

await builder.Build().RunAsync();
