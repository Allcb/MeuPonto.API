﻿using MeuPonto.Domain.Core.Events;
using MeuPonto.Infra.CrossCutting.Helpers;

namespace MeuPonto.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        //TODO
        //#region Campos Privados

        //private readonly IEventStoreRepository _repositoryEventStore;
        //private readonly IAuthFacade _serviceAuth;

        //#endregion Campos Privados

        //#region Construtores Publicos

        //public SqlEventStore(IEventStoreRepository repositoryEventStore, IAuthFacade serviceAuth)
        //{
        //    _repositoryEventStore = repositoryEventStore;
        //}

        //#endregion Construtores Publicos

        //#region Metodos Publicos

        public void Save<T>(T @event, Guid? usuarioId = null) where T : Event
        {
            StoredEvent _storedEvent = new StoredEvent(@event,
                                                       @event.ToJson(),
                                                       usuarioId.GetValueOrDefault());

            //_repositoryEventStore.Store(storedEvent);
        }

        //#endregion Metodos Publicos
    }
}