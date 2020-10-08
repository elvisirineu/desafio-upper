using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository.Pattern.Ef.DataContext;
using Repository.Pattern.Ef.UnitOfWork;
using Repository.Pattern.Ef.UnitOfWork.Contract;
using Upper.Desafio.Domain.AutoMapping;
using Upper.Desafio.Domain.Repositories.Contracts;
using Upper.Desafio.Persistence.Base;
using Upper.Desafio.Persistence.Context;
using Upper.Desafio.Persistence.Repositories;
using Upper.Desafio.Service.Domain;
using Upper.Desafio.Service.Domain.Contracts;

namespace Upper.Desafio.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string AllowSpecificOrigins = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => {
                options.AddPolicy(AllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        //.AllowCredentials()
                );
            });
            services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);

            // Add Entity Framework Core
            services.AddDbContext<UpperDesafioContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("UpperDesafioConnection"))
            );

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Dependency Injection
            services.AddScoped<IArvoreService, ArvoreService>();
            services.AddScoped<IArvoreRepository, ArvoreRepository>();

            services.AddScoped<IColheitaArvoreRepository, ColheitaArvoreRepository>();
            services.AddScoped<IColheitaRepository, ColheitaRepository>();
            services.AddScoped<IColheitaService, ColheitaService>();

            services.AddScoped<IEspecieRepository, EspecieRepository>();
            services.AddScoped<IEspecieService, EspecieService>();

            services.AddScoped<IGrupoArvoreRepository, GrupoArvoreRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IGrupoService, GrupoService>();

            

            services.AddScoped<IDataContext>(provider => provider.GetService<UpperDesafioContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Upper - Elvis Irineu Elias", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(AllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();

            //Configurando Swagger
            app.UseSwagger();
            app.UseSwaggerUI(option => option.SwaggerEndpoint("/swagger/v1/swagger.json", "get API V1"));
            app.UseWelcomePage("/swagger");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            app.Run(context =>
            {
                context.Response.Redirect("/swagger/index.html");
                return Task.CompletedTask;
            });
        }
    }
}
