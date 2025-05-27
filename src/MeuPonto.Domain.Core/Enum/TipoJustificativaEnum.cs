using System.ComponentModel;

namespace MeuPonto.Domain.Core.Enum
{
    public enum TipoJustificativaEnum
    {
        /// <summary>
        /// Atraso.
        /// </summary>
        [Description("Atraso")]
        TPJATRAS,

        /// <summary>
        /// Falta.
        /// </summary>
        [Description("Falta")]
        TPJFALTA,

        /// <summary>
        /// HoraExtra.
        /// </summary>
        [Description("HoraExtra")]
        TPJHREXT,

        /// <summary>
        /// Outro.
        /// </summary>
        [Description("Outro")]
        TPJOUTRO,
    }
}