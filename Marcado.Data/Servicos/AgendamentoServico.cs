using Marcado.Core.Entidades;
using Marcado.Core.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marcado.Data.Servicos;

public class AgendamentoServico(MarcadoDbContext db) : IAgendamentoServico
{
    private readonly MarcadoDbContext _db = db;

    public Task AgendarServicoAsync(Agendamento agendamento)
    {
        _db.Agendamentos.Add(agendamento);
        return _db.SaveChangesAsync();
    }

    public Task CancelarAgendamentoAsync(int agendamentoId)
    {
        var agendamento = _db.Agendamentos.Find(agendamentoId) ?? throw new ArgumentException("Agendamento não encontrado.");
        _db.Agendamentos.Remove(agendamento);
        return _db.SaveChangesAsync();
    }

    public async Task<List<Agendamento>> ObterAgendamentosAsync(int usuarioId, DateTime? data = null)
    {
        return await _db.Agendamentos
            .Include(a => a.Cliente)
            .Where(a => a.UsuarioId == usuarioId && (data == null || a.Data == data.Value.Date))
            .ToListAsync();
    }

    public async Task<Agendamento?> ObterAgendamentoPorIdAsync(int agendamentoId)
    {
        return await _db.Agendamentos
            .Include(a => a.Cliente)
            .FirstOrDefaultAsync(a => a.Id == agendamentoId);
    }

    public async Task AtualizarAgendamentoAsync(Agendamento agendamento)
    {
        _db.Agendamentos.Update(agendamento);
        await _db.SaveChangesAsync();
    }
}