using Marcado.App.Components;
using Marcado.Core.Servicos;
using Marcado.Core.Servicos.Interfaces;
using Marcado.Data;
using Marcado.Data.Servicos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMarcadoData(builder.Configuration);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

#region Serviços
builder.Services.AddScoped<IClientesServico, ClientesServico>();
builder.Services.AddScoped<EstadoNavegacaoServico>();
#endregion Serviços

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
