using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HomeSecuritySystem.Ui;
using HomeSecuritySystem.Ui.Services.Base;
using HomeSecuritySystem.Ui.Contracts;
using HomeSecuritySystem.Ui.Services.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(
//    sp => new HttpClient { BaseAddress = new Uri(
//        builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IClient, Client>
    (
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7275");
    }
    );

builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
await builder.Build().RunAsync();
