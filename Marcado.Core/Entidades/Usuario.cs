namespace Marcado.Core.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
    public string Plano { get; set; } = "Free"; // Free/Pro/Premium
}
