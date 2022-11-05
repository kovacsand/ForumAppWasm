using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasm;
using BlazorWasm.Auth;
using BlazorWasm.Services.Http;
using Domain.Auth;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7890") });
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

AuthorizationPolicies.AddPolicies(builder.Services);

await builder.Build().RunAsync();