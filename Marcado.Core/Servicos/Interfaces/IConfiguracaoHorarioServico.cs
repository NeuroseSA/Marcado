using Marcado.Core.Entidades;

namespace Marcado.Core.Servicos.Interfaces;

public interface IConfiguracaoHorarioServico
{
    Task<ConfiguracaoHorario?> ObterConfiguracaoAsync(int usuarioId);
    Task<ConfiguracaoHorario> SalvarConfiguracaoAsync(ConfiguracaoHorario configuracao);
    Task<ConfiguracaoHorario> CriarConfiguracaoPadraoAsync(int usuarioId);
    Task<bool> VerificarDiaAtivoAsync(int usuarioId, DayOfWeek diaSemana);
    Task<(TimeSpan inicio, TimeSpan fim)> ObterHorarioComercialAsync(int usuarioId);
}