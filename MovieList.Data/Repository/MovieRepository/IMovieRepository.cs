using System;
using System.Collections.Generic;
using System.Text;
using MovieList.Data.Repository.BaseRepository;
using MovieList.Data.Model;
using MovieList.Data.Database;

namespace MovieList.Data.Repository.MovieRepository
{
    public interface IMovieRepository : IMovieBaseRepository<Movie>
    {
    }
}
