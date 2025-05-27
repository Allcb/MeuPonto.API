using MeuPonto.Domain.Core.Models;

namespace MeuPonto.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : ProfileBase
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Entity, EntityViewModel>()
                .ReverseMap()
                .IncludeAllDerived();
        }
    }
}