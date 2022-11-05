using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasm;
using BlazorWasm.Auth;
using BlazorWasm.Services.Http;
using Domain.Auth;
using HttpClients.ClientImplementations;
using HttpClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7890") });
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IPostService, PostServiceImpl>();

AuthorizationPolicies.AddPolicies(builder.Services);

await builder.Build().RunAsync();