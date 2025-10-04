namespace Marcado.Core.Entidades;

public class Agendamento
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int? ClienteId { get; set; }
    public DateTime Data { get; set; }
    public int Hora { get; set; }
    public string Servico { get; set; } = "";
    public decimal? Valor { get; set; }
    public string Status { get; set; } = "Pendente"; // Pendente/Confirmado/Cancelado/Realizado

    // Propriedades de navegação
    public Cliente? Cliente { get; set; }
    public Usuario? Usuario { get; set; }
}
