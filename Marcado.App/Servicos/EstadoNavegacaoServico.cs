namespace Marcado.App.Servicos;

public class EstadoNavegacaoServico
{
    private readonly Dictionary<string, object> _estadoTemporario = new();

    public void DefinirClienteParaEdicao(int clienteId)
    {
        _estadoTemporario["ClienteIdEdicao"] = clienteId;
    }

    public int? ObterClienteParaEdicao()
    {
        if (_estadoTemporario.TryGetValue("ClienteIdEdicao", out var clienteId))
        {
            _estadoTemporario.Remove("ClienteIdEdicao");
            return (int)clienteId;
        }
        return null;
    }

    public void LimparEstado()
    {
        _estadoTemporario.Clear();
    }
}