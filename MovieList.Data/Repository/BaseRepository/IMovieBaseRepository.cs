using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MovieList.Data.Model;
using System.Linq;
using System.Linq.Expressions;


namespace MovieList.Data.Repository.BaseRepository
{
    public interface IMovieBaseRepository<T> where T : Movie
    {
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(ObjectId id);
        Task RemoveAsync(ObjectId id);
                   

    }
}
