using GestionDesStages.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("GestionDesStages.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GestionDesStages.ServerAPI"));

builder.Services.AddApiAuthorization();
// Pour appliquer les policy
builder.Services.AddAuthorizationCore(authorizationOptions =>
{
    authorizationOptions.AddPolicy(
        GestionDesStages.Shared.Policies.Policies.EstEntreprise,
        GestionDesStages.Shared.Policies.Policies.EstEntreprisePolicy());
    
    authorizationOptions.AddPolicy(
        GestionDesStages.Shared.Policies.Policies.EstEtudiant,
        GestionDesStages.Shared.Policies.Policies.EstEtudiantPolicy());
    /*
    authorizationOptions.AddPolicy(
        GestionDesStages.Shared.Policies.Policies.EstCoordonnateur,
        GestionDesStages.Shared.Policies.Policies.EstCoordonnateurPolicy());
    */
});


await builder.Build().RunAsync();
