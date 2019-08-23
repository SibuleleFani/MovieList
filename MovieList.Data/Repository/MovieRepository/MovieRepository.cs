using System;
using System.Collections.Generic;
using System.Text;
using MovieList.Data.Repository.BaseRepository;
using MovieList.Data.Model;
using MovieList.Data.Factory;

namespace MovieList.Data.Repository.MovieRepository
{
    public class MovieRepository: MovieBaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository (IMovieListDBFactory movieListDBFactory) : base(movieListDBFactory)
        {
        }
    }
}
