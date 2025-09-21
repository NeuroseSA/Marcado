using Marcado.Core.Entidades;

namespace Marcado.Core.Servicos;

public interface IClientesServico
{
    Task<int> AdicionarClienteAsync(Cliente cliente);
    Task<List<Cliente>> ObterClientesAsync(int usuarioId, string? filtro = null);
    Task<Cliente?> ObterClientePorIdAsync(int clienteId);
    Task AtualizarClienteAsync(Cliente cliente);
    Task DeletarClienteAsync(int clienteId);
    Task<List<Cliente>> BuscarClientesPorFiltroAsync(int usuarioId, string nome = "", string telefone = "", string email = "");
}
