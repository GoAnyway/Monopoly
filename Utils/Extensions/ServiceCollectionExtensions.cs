using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Utils.MapperProfiles;

namespace Utils.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfigurationProvider>(_ =>
                new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                {
                    new UserProfile(),
                    new MonopolyGameProfile()
                })));

            serviceCollection.AddSingleton<Mapper>();

            return serviceCollection;
        }
    }
}