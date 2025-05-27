using System.ComponentModel;

namespace MeuPonto.Domain.Core.Enum
{
    public enum TipoPontoEnum
    {
        /// <summary>
        /// Entrada.
        /// </summary>
        [Description("Entrada")]
        TPPENTRA,

        /// <summary>
        /// Saída.
        /// </summary>
        [Description("Saída")]
        TPPSAIDA,

        /// <summary>
        /// Intervalo Início.
        /// </summary>
        [Description("Intervalo Início")]
        TPPITINI,

        /// <summary>
        /// Intervalo Fim.
        /// </summary>
        [Description("Intervalo Fim")]
        TPPINFIM,

        /// <summary>
        /// Hora Extra Início.
        /// </summary>
        [Description("Hora Extra Início")]
        TPPHEINI,

        /// <summary>
        /// Hora Extra Fim.
        /// </summary>
        [Description("Hora Extra Fim")]
        TPPHEFIM,
    }
}