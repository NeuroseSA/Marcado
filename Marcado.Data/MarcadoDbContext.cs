using Marcado.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Marcado.Data;

public class MarcadoDbContext : DbContext
{
    public MarcadoDbContext(DbContextOptions<MarcadoDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Agendamento> Agendamentos => Set<Agendamento>();
    public DbSet<ConfiguracaoHorario> ConfiguracoesHorario => Set<ConfiguracaoHorario>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Usuario>()
            .HasIndex(x => x.Email).IsUnique();

        b.Entity<Cliente>()
            .HasIndex(x => new { x.UsuarioId, x.Nome });

        b.Entity<Agendamento>()
            .HasOne(a => a.Cliente)
            .WithMany()
            .HasForeignKey(a => a.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
            
        b.Entity<Agendamento>(e =>
        {
            e.Property(a => a.Valor).HasColumnType("decimal(18,2)");
        });

        b.Entity<Agendamento>()
            .HasOne(a => a.Usuario)
            .WithMany()
            .HasForeignKey(a => a.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<ConfiguracaoHorario>()
            .HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<ConfiguracaoHorario>()
            .HasIndex(c => c.UsuarioId)
            .IsUnique();
    }
}
