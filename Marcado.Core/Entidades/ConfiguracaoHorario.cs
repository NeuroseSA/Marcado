namespace Marcado.Core.Entidades;

public class ConfiguracaoHorario
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public TimeSpan HoraInicio { get; set; } = new(8, 0, 0);
    public TimeSpan HoraFim { get; set; } = new(18, 0, 0);
    public int IntervaloSlots { get; set; } = 60; // Em minutos
    public bool SegundaAtiva { get; set; } = true;
    public bool TercaAtiva { get; set; } = true;
    public bool QuartaAtiva { get; set; } = true;
    public bool QuintaAtiva { get; set; } = true;
    public bool SextaAtiva { get; set; } = true;
    public bool SabadoAtiva { get; set; } = false;
    public bool DomingoAtiva { get; set; } = false;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public DateTime? DataAtualizacao { get; set; }

    // Propriedades de navegação
    public Usuario? Usuario { get; set; }
}