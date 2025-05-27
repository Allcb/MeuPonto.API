using MediatR;
using MeuPonto.Domain.Core.Bus;
using MeuPonto.Domain.Core.Commands;
using MeuPonto.Domain.Core.Notifications;
using MeuPonto.Domain.Interfaces.UoW;

namespace MeuPonto.Domain.CommandHandlers
{
    public class CommandHandler
    {
        #region Campos Privados

        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        #endregion Campos Privados

        #region Construtores Publicos

        public CommandHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        #endregion Construtores Publicos

        #region Metodos Protegidos

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        #endregion Metodos Protegidos

        #region Metodos Publicos

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            if (_uow.Commit())
                return true;
            else if (!_uow.Commit() && !string.IsNullOrEmpty(_uow.GetCommitExceptionMessage()))
                _bus.RaiseEvent(new DomainNotification("Commit", $"Tivemos um problema para salvar os dados. {_uow.GetCommitExceptionMessage()}, por favor tente novamente."));

            _bus.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema para salvar os dados."));
            return false;
        }

        #endregion Metodos Publicos
    }
}