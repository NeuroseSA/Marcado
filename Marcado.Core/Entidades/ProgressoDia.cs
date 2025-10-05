using Marcado.Core.Entidades.Enum;

namespace Marcado.Core.Entidades
{
    public class ProgressoDia
    {
        public int Percentual { get; set; }
        public string StatusTexto { get; set; } = "";
        public StatusDia TipoStatus { get; set; }
        public string StatusCss { get; set; } = string.Empty;
    }
}