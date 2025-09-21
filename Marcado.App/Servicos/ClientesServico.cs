using Marcado.Core.Entidades;
using Marcado.Core.Servicos;
using Marcado.Data;
using Microsoft.EntityFrameworkCore;

namespace Marcado.App.Servicos;

public class ClientesServico(MarcadoDbContext db) : IClientesServico
{
    private readonly MarcadoDbContext _db = db;

    public async Task<int> AdicionarClienteAsync(Cliente cliente)
    {
        _db.Clientes.Add(cliente);
        await _db.SaveChangesAsync();
        return cliente.Id;
    }

    public async Task<List<Cliente>> ObterClientesAsync(int usuarioId, string? filtro = null)
    {
        var q = _db.Clientes.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(filtro))
            q = q.Where(x => x.Nome.Contains(filtro));
        return await q.OrderBy(x => x.Nome).ToListAsync();
    }

    public async Task<Cliente?> ObterClientePorIdAsync(int clienteId)
    {
        return await _db.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == clienteId);
    }

    public async Task AtualizarClienteAsync(Cliente cliente)
    {
        var clienteExistente = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id) ?? throw new Exception("Cliente não encontrado.");
        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Email = cliente.Email;
        clienteExistente.Telefone = cliente.Telefone;
        clienteExistente.Observacao = cliente.Observacao;

        await _db.SaveChangesAsync();
    }

    public async Task DeletarClienteAsync(int clienteId)
    {
        var cliente = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == clienteId) ?? throw new Exception("Cliente não encontrado.");
        _db.Clientes.Remove(cliente);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Cliente>> BuscarClientesPorFiltroAsync(int usuarioId, string nome = "", string telefone = "", string email = "")
    {
        var query = _db.Clientes.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome))
            query = query.Where(c => c.Nome.Contains(nome));

        if (!string.IsNullOrWhiteSpace(telefone))
            query = query.Where(c => c.Telefone.Contains(telefone));

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(c => c.Email.Contains(email));

        return await query.OrderBy(c => c.Nome).ToListAsync();
    }
}
