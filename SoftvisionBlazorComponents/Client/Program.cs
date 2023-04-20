using CSVBlazor.BaseComponents;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SoftvisionBlazorComponents.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var jsRunTime = builder.Build().Services.GetRequiredService<IJSRuntime>(); // get the service from the service provider
builder.Services.AddScoped(sp => new JSInteropHelper(jsRunTime));

await builder.Build().RunAsync();
