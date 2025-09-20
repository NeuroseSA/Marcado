namespace Marcado.Core.Entidades;

public class Cliente
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Nome { get; set; } = "";
    public string Telefone { get; set; } = "";
    public string Observacao { get; set; } = "";
}
