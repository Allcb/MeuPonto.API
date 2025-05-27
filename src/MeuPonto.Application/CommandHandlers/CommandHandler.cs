using MeuPonto.Domain.Core.Bus;
using MeuPonto.Domain.Core.Commands;
using MeuPonto.Domain.Core.Enum;
using MeuPonto.Domain.Core.Events;
using MeuPonto.Domain.Core.Extensions;
using MeuPonto.Domain.Core.Notifications;
using MeuPonto.Domain.Interfaces.UoW;
using MeuPonto.Infra.CrossCutting.Helpers;
using FluentValidation.Results;
using MediatR;

namespace MeuPonto.Application.CommandHandlers
{
    public class CommandHandler
    {
        #region Campos Privados

        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        private readonly IUnitOfWork _uow;

        #endregion Campos Privados

        #region Construtores Publicos

        public CommandHandler(IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications,
                              IUnitOfWork uow)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
            _uow = uow;
        }

        #endregion Construtores Publicos

        #region Metodos Protegidos

        protected bool CommandValido(Command command)
        {
            if (command.EValido())
                return true;

            NotifyValidationErrors(command);
            return false;
        }

        protected bool CommandValido(params Command[] commands)
        {
            foreach (Command command in commands)
            {
                if (command is not null && !CommandValido(command))
                    return false;
            }

            return true;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (ValidationFailure error in message.ValidationResult.Errors)
                _mediator.RaiseEvent(new DomainNotification(key: message.MessageType,
                                                            value: error.ErrorMessage));
        }

        protected void NotifyValidationErrors<TReturn>(DynamicCommand<TReturn> message)
        {
            foreach (ValidationFailure error in message.ValidationResult.Errors)
                _mediator.RaiseEvent(new DomainNotification(key: message.MessageType,
                                                            value: error.ErrorMessage));
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
                _mediator.RaiseEvent(new DomainNotification(key: "Commit",
                                                            value: _uow.GetCommitExceptionMessage()));

            _mediator.RaiseEvent(new DomainNotification(key: "Commit",
                                                        value: ApiErrorCodes.ERROPBD.GetDescription()));

            return false;
        }

        public async Task<bool> CommitAndRaiseEvent<TCommand, TEvent>(TCommand command, Guid? usuarioId = null) where TEvent : Event
        {
            bool _commitedSuccessfully = Commit();

            if (_commitedSuccessfully)
                await _mediator.RaiseEvent(@event: command.Cast<TEvent>(),
                                           usuarioId: usuarioId);

            return _commitedSuccessfully;
        }

        #endregion Metodos Publicos
    }
}