using API.Mediatr;
using BL.Abstraction;
using BL.Implementation;
using DAL.Configuration;
using DAL.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Mvc
            services.AddMvc();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "RAGC",
                    Version = "v1"
                });
            });

            //Mediatr
            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<SingleInstanceFactory>(sp => sp.GetService);
            services.AddTransient<MultiInstanceFactory>(sp => sp.GetServices);
            services.AddMediatorHandlers(typeof(Startup).Assembly);

            //MongoDB
            services.Configure<MongoSettings>(o =>
            {
                o.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                o.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddSingleton<IMongoClient, MongoClient>(c => new MongoClient(Configuration.GetSection("MongoConnection:ConnectionString").Value));

            //BL
            services.AddTransient<IUserService, UserService>();

            //DAL
            services.AddTransient<IRepository, Repository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RAGC API");
            });

            //Mvc
            app.UseMvc();
        }
    }
}
