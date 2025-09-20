using Marcado.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Marcado.Data;

public class MarcadoDbContext : DbContext
{
    public MarcadoDbContext(DbContextOptions<MarcadoDbContext> options) : base(options) {}

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Agendamento> Agendamentos => Set<Agendamento>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Usuario>()
            .HasIndex(x => x.Email).IsUnique();

        b.Entity<Cliente>()
            .HasIndex(x => new { x.UsuarioId, x.Nome });

        b.Entity<Agendamento>()
            .HasOne<Cliente>()
            .WithMany()
            .HasForeignKey(x => x.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
