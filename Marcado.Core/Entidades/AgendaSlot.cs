namespace Marcado.Core.Entidades
{
    public class AgendaSlot
    {
        public int Hora { get; set; }
        public string Status { get; set; } = "Livre";
        public string Descricao { get; set; } = "";
        public Cliente? Cliente { get; set; }
        public int? AgendamentoId { get; set; }
    }
}