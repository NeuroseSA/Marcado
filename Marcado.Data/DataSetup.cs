using Marcado.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marcado.Data;

public static class DataSetup
{
    public static IServiceCollection AddMarcadoData(this IServiceCollection services, IConfiguration cfg)
    {
        var cs = cfg.GetConnectionString("MarcadoDb")!;
        services.AddDbContext<MarcadoDbContext>(opt => opt.UseSqlite(cs));
        return services;
    }

    public static void SeedData(MarcadoDbContext context)
    {
        // Garantir que o banco foi criado
        context.Database.EnsureCreated();

        // Se já existem usuários, não fazer seed novamente
        if (context.Usuarios.Any())
            return;

        // Criar usuário padrão
        var usuario = new Usuario
        {
            Nome = "Administrador",
            Email = "admin@marcado.app",
            Plano = "Premium"
        };
        context.Usuarios.Add(usuario);
        context.SaveChanges();

        // Criar clientes de exemplo
        var clientes = new List<Cliente>
        {
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Maria Silva",
                Telefone = "11987654321",
                Email = "maria.silva@email.com",
                Observacao = "Cliente VIP - Prefere horários da manhã"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "João Santos",
                Telefone = "11876543210",
                Email = "joao.santos@email.com",
                Observacao = "Cliente regular - Corte mensal"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Ana Costa",
                Telefone = "11765432109",
                Email = "ana.costa@email.com",
                Observacao = "Alérgica a produtos com amônia"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Carlos Oliveira",
                Telefone = "11654321098",
                Email = "carlos.oliveira@email.com",
                Observacao = "Cliente executivo - Prefere agendamentos após 18h"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Fernanda Lima",
                Telefone = "11543210987",
                Email = "fernanda.lima@email.com",
                Observacao = "Grávida - Cuidados especiais com produtos químicos"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Roberto Ferreira",
                Telefone = "11432109876",
                Email = "roberto.ferreira@email.com",
                Observacao = "Cliente há 5 anos - Desconto de fidelidade"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Juliana Rodrigues",
                Telefone = "11321098765",
                Email = "juliana.rodrigues@email.com",
                Observacao = "Cabelos cacheados - Especialista em produtos naturais"
            },
            new Cliente
            {
                UsuarioId = usuario.Id,
                Nome = "Pedro Almeida",
                Telefone = "11210987654",
                Email = "pedro.almeida@email.com",
                Observacao = "Barba completa quinzenalmente"
            }
        };

        context.Clientes.AddRange(clientes);
        context.SaveChanges();
    }
}
