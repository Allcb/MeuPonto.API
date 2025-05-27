using AutoMapper;

namespace MeuPonto.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new DomainToViewModelMappingProfile());
                configuration.AddProfile(new CommandToDomainMappingProfile());
                configuration.AddProfile(new ViewModelToCommandMappingProfile());
            });
        }
    }
}