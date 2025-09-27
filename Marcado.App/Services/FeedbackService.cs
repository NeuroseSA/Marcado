namespace Marcado.App.Services;

public class FeedbackService
{
    public event Action<string, string, TipoFeedback, int>? OnMostrarFeedback;

    public void MostrarSucesso(string titulo, string mensagem, int duracao = 5000)
    {
        OnMostrarFeedback?.Invoke(titulo, mensagem, TipoFeedback.Sucesso, duracao);
    }

    public void MostrarErro(string titulo, string mensagem, int duracao = 7000)
    {
        OnMostrarFeedback?.Invoke(titulo, mensagem, TipoFeedback.Erro, duracao);
    }

    public void MostrarAlerta(string titulo, string mensagem, int duracao = 6000)
    {
        OnMostrarFeedback?.Invoke(titulo, mensagem, TipoFeedback.Alerta, duracao);
    }

    public void MostrarInfo(string titulo, string mensagem, int duracao = 5000)
    {
        OnMostrarFeedback?.Invoke(titulo, mensagem, TipoFeedback.Info, duracao);
    }
}

public enum TipoFeedback
{
    Sucesso,
    Erro,
    Alerta,
    Info
}