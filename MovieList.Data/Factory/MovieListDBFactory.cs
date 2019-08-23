using MovieList.Data.Model;
using Microsoft.Extensions.Options;
using MovieList.Data.Database;

namespace MovieList.Data.Factory
{
    public class MovieListDBFactory : IMovieListDBFactory 
    {
        private readonly IOptions<MovieDatabaseSettings> _configuration;

        public MovieListDBFactory(IOptions<MovieDatabaseSettings> configuration)
        {
            _configuration = configuration;
        }
        public IMovieDBContext GetMovieDBContext()
        {
            return GetMovieDBSettings();
        }

        private IMovieDBContext GetMovieDBSettings()
        {
            return new MovieDBContext(
                _configuration.Value.ConnectionString,
                _configuration.Value.DatabaseName,
                _configuration.Value.MovieCollectionName);
        }

    }
}
