using System;
using System.Collections.Generic;
using System.Text;
using MovieList.Data.Database;

namespace MovieList.Data.Factory
{
    public interface IMovieListDBFactory
    {
        IMovieDBContext GetMovieDBContext();
    }
}
