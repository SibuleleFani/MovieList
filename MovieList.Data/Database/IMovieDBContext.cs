using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MovieList.Data.Model;
using System.Linq;
using System.Linq.Expressions;

namespace MovieList.Data.Database
{
    public interface IMovieDBContext 
    {
        Task AddAsync<T>(T entity) where T : Movie;
        Task<T> GetByIdAsync<T>(ObjectId id) where T : Movie;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : Movie;
        Task UpdateAsync<T>(T entity) where T : Movie;
        Task RemoveAsync<T>(ObjectId id) where T : Movie;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : Movie;         
          
          
            
           
         

    }
}

