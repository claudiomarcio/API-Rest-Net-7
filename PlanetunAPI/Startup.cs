using PlanetunAPI.Services;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<IPlanetunService, PlanetunService>();          
                  
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });
            //services.Configure<MvcOptions>(options => {
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            //});

            services.AddMvc();
            services.AddCors();

        }

        public void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app. Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

        }
    }
}