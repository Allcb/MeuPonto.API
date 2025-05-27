using AutoMapper;
using MeuPonto.Application.Interfaces;
using MeuPonto.Domain.Core.Bus;

namespace MeuPonto.Application.Services
{
    public class RegistroPontoAppService : IRegistroPontoAppService
    {
        #region Campos Privados

        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        #endregion Campos Privados

        #region Construtores Publicos

        public RegistroPontoAppService(IMapper mapper,
                                       IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #endregion Construtores Publicos
    }
}