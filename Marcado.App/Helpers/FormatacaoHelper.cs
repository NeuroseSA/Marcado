namespace Marcado.App.Helpers;

public static class FormatacaoHelper
{
    /// <summary>
    /// Aplica máscara de telefone no formato (11) 99999-9999 ou (11) 9999-9999
    /// </summary>
    public static string FormatarTelefone(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
            return string.Empty;

        // Remove todos os caracteres não numéricos
        var numeroLimpo = new string(telefone.Where(char.IsDigit).ToArray());

        if (numeroLimpo.Length == 0)
            return string.Empty;

        // Aplica a máscara baseado na quantidade de dígitos
        return numeroLimpo.Length switch
        {
            10 => $"({numeroLimpo[..2]}) {numeroLimpo[2..6]}-{numeroLimpo[6..]}",
            11 => $"({numeroLimpo[..2]}) {numeroLimpo[2..7]}-{numeroLimpo[7..]}",
            _ when numeroLimpo.Length < 10 => numeroLimpo,
            _ => numeroLimpo[..11] // Limita a 11 dígitos se houver mais
        };
    }

    /// <summary>
    /// Remove a máscara do telefone, retornando apenas os números
    /// </summary>
    public static string RemoverMascaraTelefone(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
            return string.Empty;

        return new string(telefone.Where(char.IsDigit).ToArray());
    }

    /// <summary>
    /// Aplica máscara de telefone enquanto o usuário digita
    /// </summary>
    public static string AplicarMascaraTelefoneInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Remove caracteres não numéricos
        var numeroLimpo = new string(input.Where(char.IsDigit).ToArray());

        if (numeroLimpo.Length == 0)
            return string.Empty;

        // Aplica máscara progressivamente conforme o usuário digita
        return numeroLimpo.Length switch
        {
            1 => $"({numeroLimpo}",
            2 => $"({numeroLimpo})",
            3 => $"({numeroLimpo[..2]}) {numeroLimpo[2]}",
            4 => $"({numeroLimpo[..2]}) {numeroLimpo[2..4]}",
            5 => $"({numeroLimpo[..2]}) {numeroLimpo[2..5]}",
            6 => $"({numeroLimpo[..2]}) {numeroLimpo[2..6]}",
            7 => $"({numeroLimpo[..2]}) {numeroLimpo[2..6]}-{numeroLimpo[6]}",
            8 => $"({numeroLimpo[..2]}) {numeroLimpo[2..6]}-{numeroLimpo[6..8]}",
            9 => $"({numeroLimpo[..2]}) {numeroLimpo[2..6]}-{numeroLimpo[6..9]}",
            10 => $"({numeroLimpo[..2]}) {numeroLimpo[2..6]}-{numeroLimpo[6..10]}",
            >= 11 => $"({numeroLimpo[..2]}) {numeroLimpo[2..7]}-{numeroLimpo[7..11]}",
            _ => numeroLimpo
        };
    }
}