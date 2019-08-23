using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MovieList.Data.Model;
using MovieList.Data.Database;
using System.Linq;
using System.Linq.Expressions;
using MovieList.Data.Factory;


namespace MovieList.Data.Repository.BaseRepository
{
    public class MovieBaseRepository<T> : IMovieBaseRepository<T> where T : Movie
    {
        private readonly IMovieDBContext _movieListDb;

        public MovieBaseRepository(IMovieListDBFactory movieListDBFactory)
        {
            _movieListDb = movieListDBFactory.GetMovieDBContext();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _movieListDb.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync() 
        {
            return await _movieListDb.GetAllAsync<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _movieListDb.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _movieListDb.UpdateAsync(entity);
        }
        public async Task RemoveAsync(ObjectId id)
        {
            await _movieListDb.RemoveAsync<T>(id);
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _movieListDb.GetByIdAsync<T>(id);
        }
    }
}
