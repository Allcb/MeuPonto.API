using MediatR;
using MeuPonto.Application.Interfaces;
using MeuPonto.Application.Services;
using MeuPonto.Domain.CommandHandlers;
using MeuPonto.Domain.Commands.RegistroPonto;
using MeuPonto.Domain.Core.Bus;
using MeuPonto.Domain.Core.Events;
using MeuPonto.Domain.Core.Notifications;
using MeuPonto.Domain.Interfaces.Repositories;
using MeuPonto.Domain.Interfaces.UoW;
using MeuPonto.Infra.CrossCutting.Bus;
using MeuPonto.Infra.CrossCutting.Chain.Extensions;
using MeuPonto.Infra.CrossCutting.Chain.Providers.HttpHandlers;
using MeuPonto.Infra.Data.Context;
using MeuPonto.Infra.Data.EventSourcing;
using MeuPonto.Infra.Data.Repositories;
using MeuPonto.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MeuPonto.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        #region Metodos Publicos

        public static void RegisterServices(IServiceCollection services)
        {
            #region Contexts

            services.AddDbContext<MeuPontoContext>();
            services.AddDbContext<EventStoreSQLContext>();

            #endregion Contexts

            #region Chain

            services.ConfigureChain<HttpResponseHandle>(new StatusOk())
                    .Next(new StatusAccepted())
                    .Next(new StatusCreated())
                    .Next(new StatusNoContent())
                    .Next(new StatusNotFound())
                    .Next(new StatusForbidden())
                    .Next(new StatusBadRequest())
                    .Next(new StatusUnauthorized())
                    .Next(new StatusInternalServerError())
                    .Next(new StatusConflict())
                    .Next(new DefaultStatus());

            #endregion Chain

            #region Singleton

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion Singleton

            #region Scoped

            #region AppServices

            services.AddScoped<IRegistroPontoAppService, RegistroPontoAppService>();

            #endregion AppServices

            #region Domain - Bus (Mediator)

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            #endregion Domain - Bus (Mediator)

            #region 'Domain - Commands'

            services.AddScoped<IRequestHandler<RegistroPontoCriarCommand, bool>, RegistroPontoCommandHandler>();

            #endregion 'Domain - Commands'

            #region Domain - Notifications

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #endregion Domain - Notifications

            #region Infra - Data EventSourcing

            services.AddScoped<IEventStore, SqlEventStore>();
            // services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();

            #endregion Infra - Data EventSourcing

            #region Infra - Data uow

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion Infra - Data uow

            #region Repositories

            services.AddScoped<IRegistroPontoRepository, RegistroPontoRepository>();

            #endregion Repositories

            #endregion Scoped
        }

        #endregion Metodos Publicos
    }
}