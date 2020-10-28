using AutoMapper;
using DataManager;
using DataManager.StubStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monopoly.GameCommunication;
using Utils.MapperProfiles;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Monopoly
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
#if TEST || DEBUG
            services.AddSingleton<IUserStorage, StubUserStorage>();
#else
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MonopolyContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IUserStorage, DbUserStorage>();
#endif
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Authorization/Login");
                    options.AccessDeniedPath = options.LoginPath;
                });
            services.AddSingleton<IConfigurationProvider>(_ =>
                new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                {
                    new UserProfile(),
                    new MonopolyGameProfile()
                })));
            services.AddSingleton<Mapper>();
            services.AddScoped<MonopolyGameCommunication, MonopolyGameCommunication>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}