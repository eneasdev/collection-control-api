using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using collection_control_api.Interfaces;
using collection_control_api.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation.AspNetCore;
using collection_control_api.Models.InputModels.Book;
using collection_control_api.API.Filters;

namespace collection_control_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewBookInputModel>());

            var connectionString = Configuration.GetConnectionString("ColletionString");
            services.AddDbContext<CollectionContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.EnableSensitiveDataLogging();
                });

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICdRepository, CdRepository>();
            services.AddScoped<IDvdRepository, DvdRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "collection_control_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "collection-control-api"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
