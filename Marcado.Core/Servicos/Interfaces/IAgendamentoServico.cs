using Marcado.Core.Entidades;

namespace Marcado.Core.Servicos.Interfaces;

public interface IAgendamentoServico
{
    Task AgendarServicoAsync(Agendamento agendamento);
    Task<List<Agendamento>> ObterAgendamentosAsync(int usuarioId, DateTime? data = null);
    Task<Agendamento?> ObterAgendamentoPorIdAsync(int agendamentoId);
    Task AtualizarAgendamentoAsync(Agendamento agendamento);
    Task CancelarAgendamentoAsync(int agendamentoId);
}