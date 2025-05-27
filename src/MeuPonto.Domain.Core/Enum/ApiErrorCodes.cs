using MeuPonto.Domain.Core.Attributes;
using Microsoft.AspNetCore.Http;

namespace MeuPonto.Domain.Core.Enum
{
    public enum ApiErrorCodes
    {
        #region 500 Status (Internal Server Error)

        /// <summary>
        /// Erro inesperado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro inesperado.", "Contate o administrador do sistema.")]
        UNEXPC,

        /// <summary>
        /// Erro ao executar operação no banco de dados.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao executar operação no banco de dados.")]
        ERROPBD,

        #endregion 500 Status (Internal Server Error)

        #region 400 Status (Bad request)

        /// <summary>
        /// Não há vagas disponíveis .
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Não há vagas disponíveis no momento, aguarde uma compatível ser liberada.")]
        NOVAGA,

        #endregion 400 Status (Bad request)

        #region 404 Status (Not found)

        /// <summary>
        /// Ponto não encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Ponto não encontrado.")]
        PTONOTFND,

        #endregion 404 Status (Not found)
    }
}