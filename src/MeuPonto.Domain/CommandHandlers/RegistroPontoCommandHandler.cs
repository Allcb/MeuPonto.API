using AutoMapper;
using MediatR;
using MeuPonto.Domain.Commands.RegistroPonto;
using MeuPonto.Domain.Core.Bus;
using MeuPonto.Domain.Core.Notifications;
using MeuPonto.Domain.Interfaces.UoW;
using MeuPonto.Domain.Models;

namespace MeuPonto.Domain.CommandHandlers
{
    public class RegistroPontoCommandHandler : CommandHandler, IRequestHandler<RegistroPontoCriarCommand, bool>
    {
        #region Campos Privados

        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        #endregion Campos Privados

        #region Construtores Publicos

        public RegistroPontoCommandHandler(IMapper mapper,
                                           IMediatorHandler bus,
                                           IUnitOfWork uow,
                                           INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _mapper = mapper;
            _bus = bus;
        }

        #endregion Construtores Publicos

        #region Metodos Publicos

        public async Task<bool> Handle(RegistroPontoCriarCommand requisicao, CancellationToken cancellationToken)
        {
            if (!requisicao.EValido())
            {
                NotifyValidationErrors(requisicao);
                return false;
            }

            Perfil _perfil = _mapper.Map<Perfil>(requisicao);

            //await _registroPontoRepository.CreateAsync();

            bool _commitComSucesso = Commit();

            return _commitComSucesso;
        }

        #endregion Metodos Publicos
    }
}