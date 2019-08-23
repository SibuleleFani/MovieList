using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieList.Data.Model;
using MovieList.Data.Repository.MovieRepository;
using Microsoft.Extensions.Configuration;
using MovieList.Data.Factory;

namespace MovieList.Data.Service
{
    public static class MovieServiceConfig
    {
        public static void movieConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<MovieDatabaseSettings>>().Value);
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieListDBFactory, MovieListDBFactory>();
        }
    }
}
