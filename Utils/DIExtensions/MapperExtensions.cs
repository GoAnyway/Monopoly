using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Utils.MapperProfiles;

namespace Utils.DIExtensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConfigurationProvider>(_ =>
                new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                {
                    new UserProfile(),
                    new MonopolyGameProfile()
                })));

            serviceCollection.AddScoped<Mapper>();

            return serviceCollection;
        }
    }
}