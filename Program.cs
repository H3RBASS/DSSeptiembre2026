using DSSeptiembre;
using DSSeptiembre.Shared.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Supabase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//conexion a supabase

var supabaseOptions = builder.Configuration
    .GetSection("Supabase")
    .Get<SupabaseConfiguration>();

var client = new Client(
    supabaseOptions!.Url,
    supabaseOptions.Key
);

await client.InitializeAsync();

builder.Services.AddSingleton(client);
Console.WriteLine(client);

//fin conexion a supabase

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

await builder.Build().RunAsync();