using Marcado.App.Components;
using Marcado.App.Servicos;
using Marcado.Core.Servicos;
using Marcado.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMarcadoData(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

#region Serviços
builder.Services.AddScoped<IClientesServico, ClientesServico>();
builder.Services.AddScoped<EstadoNavegacaoServico>();
#endregion Serviços

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
