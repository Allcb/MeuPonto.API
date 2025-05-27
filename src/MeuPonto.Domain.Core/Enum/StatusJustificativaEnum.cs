using System.ComponentModel;

namespace MeuPonto.Domain.Core.Enum
{
    public enum StatusJustificativaEnum
    {
        /// <summary>
        /// Aprovado.
        /// </summary>
        [Description("Aprovado")]
        STJAPROV,

        /// <summary>
        /// Pendente.
        /// </summary>
        [Description("Pendente")]
        STJPENDE,

        /// <summary>
        /// Rejeitado.
        /// </summary>
        [Description("Rejeitado")]
        STJREJEI,

        /// <summary>
        /// Cancelado.
        /// </summary>
        [Description("Cancelado")]
        STJCANCE,
    }
}