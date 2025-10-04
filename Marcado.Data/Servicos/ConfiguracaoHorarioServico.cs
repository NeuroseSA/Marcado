using Marcado.Core.Entidades;
using Marcado.Core.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marcado.Data.Servicos;

public class ConfiguracaoHorarioServico(MarcadoDbContext db) : IConfiguracaoHorarioServico
{
    private readonly MarcadoDbContext _db = db;

    public async Task<ConfiguracaoHorario?> ObterConfiguracaoAsync(int usuarioId)
    {
        return await _db.ConfiguracoesHorario
            .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
    }

    public async Task<ConfiguracaoHorario> SalvarConfiguracaoAsync(ConfiguracaoHorario configuracao)
    {
        var configuracaoExistente = await ObterConfiguracaoAsync(configuracao.UsuarioId);
        
        if (configuracaoExistente != null)
        {
            // Atualizar configuração existente
            configuracaoExistente.HoraInicio = configuracao.HoraInicio;
            configuracaoExistente.HoraFim = configuracao.HoraFim;
            configuracaoExistente.IntervaloSlots = configuracao.IntervaloSlots;
            configuracaoExistente.SegundaAtiva = configuracao.SegundaAtiva;
            configuracaoExistente.TercaAtiva = configuracao.TercaAtiva;
            configuracaoExistente.QuartaAtiva = configuracao.QuartaAtiva;
            configuracaoExistente.QuintaAtiva = configuracao.QuintaAtiva;
            configuracaoExistente.SextaAtiva = configuracao.SextaAtiva;
            configuracaoExistente.SabadoAtiva = configuracao.SabadoAtiva;
            configuracaoExistente.DomingoAtiva = configuracao.DomingoAtiva;
            configuracaoExistente.DataAtualizacao = DateTime.Now;
            
            _db.ConfiguracoesHorario.Update(configuracaoExistente);
            await _db.SaveChangesAsync();
            return configuracaoExistente;
        }
        else
        {
            // Criar nova configuração
            _db.ConfiguracoesHorario.Add(configuracao);
            await _db.SaveChangesAsync();
            return configuracao;
        }
    }

    public async Task<ConfiguracaoHorario> CriarConfiguracaoPadraoAsync(int usuarioId)
    {
        var configuracaoPadrao = new ConfiguracaoHorario
        {
            UsuarioId = usuarioId,
            HoraInicio = new TimeSpan(8, 0, 0),
            HoraFim = new TimeSpan(18, 0, 0),
            IntervaloSlots = 60,
            SegundaAtiva = true,
            TercaAtiva = true,
            QuartaAtiva = true,
            QuintaAtiva = true,
            SextaAtiva = true,
            SabadoAtiva = false,
            DomingoAtiva = false
        };

        return await SalvarConfiguracaoAsync(configuracaoPadrao);
    }

    public async Task<bool> VerificarDiaAtivoAsync(int usuarioId, DayOfWeek diaSemana)
    {
        var configuracao = await ObterConfiguracaoAsync(usuarioId);
        if (configuracao == null) return false;

        return diaSemana switch
        {
            DayOfWeek.Monday => configuracao.SegundaAtiva,
            DayOfWeek.Tuesday => configuracao.TercaAtiva,
            DayOfWeek.Wednesday => configuracao.QuartaAtiva,
            DayOfWeek.Thursday => configuracao.QuintaAtiva,
            DayOfWeek.Friday => configuracao.SextaAtiva,
            DayOfWeek.Saturday => configuracao.SabadoAtiva,
            DayOfWeek.Sunday => configuracao.DomingoAtiva,
            _ => false
        };
    }

    public async Task<(TimeSpan inicio, TimeSpan fim)> ObterHorarioComercialAsync(int usuarioId)
    {
        var configuracao = await ObterConfiguracaoAsync(usuarioId);
        if (configuracao == null)
        {
            // Retorna horário padrão se não há configuração
            return (new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0));
        }

        return (configuracao.HoraInicio, configuracao.HoraFim);
    }
}