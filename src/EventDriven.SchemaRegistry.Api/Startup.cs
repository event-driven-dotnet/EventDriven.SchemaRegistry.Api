using EventDriven.SchemaRegistry.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EventDriven.SchemaRegistry.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EventDriven.SchemaRegistry.Api", Version = "v1"});
            });
            
            // Configuration
            var stateStoreOptions = new MongoStateStoreOptions();
            Configuration.GetSection(nameof(MongoStateStoreOptions)).Bind(stateStoreOptions);
            
            // Dapr Schema Registry
            services.AddMongoSchemaRegistry(options =>
            {
                options.ConnectionString = stateStoreOptions.ConnectionString;
                options.DatabaseName = stateStoreOptions.DatabaseName;
                options.SchemasCollectionName = stateStoreOptions.SchemasCollectionName;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventDriven.SchemaRegistry.Api v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}