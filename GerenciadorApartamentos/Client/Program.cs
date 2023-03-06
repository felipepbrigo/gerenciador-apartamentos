global using GerenciadorApartamentos.Client.Services.ApartmentServices;
global using GerenciadorApartamentos.Client.Services.BuildingServices;
global using GerenciadorApartamentos.Client.Services.TenantServices;
global using GerenciadorApartamentos.Client.Services.LandlordServices;
global using GerenciadorApartamentos.Client.Services.RentalServices;
global using GerenciadorApartamentos.Shared;
using GerenciadorApartamentos.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<ILandlordService, LandlordService>();
builder.Services.AddScoped<IRentalService, RentalService>();

await builder.Build().RunAsync();
