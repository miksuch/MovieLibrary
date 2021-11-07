using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Core.Services;
using MovieLibrary.Core.Services.Implementations;
using MovieLibrary.Data;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Api
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
            services.AddEntityFrameworkSqlite().AddDbContext<MovieLibraryContext>();

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie library API", Version = "v1" });
            });

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie library API");
            });

            app.UseExceptionHandler("/Error");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
