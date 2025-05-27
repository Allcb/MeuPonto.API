using MeuPonto.Domain.Core.Enum;
using MeuPonto.Infra.CrossCutting.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MeuPonto.Infra.CrossCutting.Chain.Providers.HttpHandlers
{
    public class DefaultStatus : HttpResponseHandle
    {
        public override IActionResult Handle(object result, ApiErrorCodes apiErrorCode, HttpStatusCode statusCode)
        {
            throw new ApiException(requestData: result,
                                   apiErrorCode: apiErrorCode,
                                   httpStatusCode: statusCode,
                                   messages: "Status não implementado!");
        }
    }
}