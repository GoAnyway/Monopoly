using AutoMapper;
using Database;
using DataManager.GameStorages;
using DataManager.GameStorages.DbStorages;
using DataManager.GameStorages.StubStorages;
using DataManager.UserStorages;
using DataManager.UserStorages.DbStorage;
using DataManager.UserStorages.StubStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monopoly.Authentication;
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
            services.AddControllers();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "MonopolyGame.Session";
                options.Cookie.IsEssential = true;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/api/Authorization/Login");
                    options.AccessDeniedPath = options.LoginPath;
                });

#if TEST || DEBUG
            services.AddSingleton<IUserStorage, StubUserStorage>();
            services.AddSingleton<IGameCreationStorage, StubGameCreationStorage>();
            services.AddSingleton<IMonopolyGameStorage, StubMonopolyGameStorage>();
#else
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MonopolyContext>(options => options.UseSqlServer(connection));

            services.AddSingleton<IUserStorage, DbUserStorage>();
            services.AddSingleton<IGameCreationStorage, DbGameCreationStorage>();
            services.AddSingleton<IMonopolyGameStorage, DbMonopolyGameStorage>();
#endif

            services.AddSingleton<IConfigurationProvider>(_ =>
                new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                {
                    new UserProfile(),
                    new MonopolyGameProfile()
                })));
            services.AddSingleton<Mapper>();
            services.AddSingleton<IAuthentication, CookieAuthentication>();
            services.AddScoped<MonopolyGameCommunication, MonopolyGameCommunication>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}