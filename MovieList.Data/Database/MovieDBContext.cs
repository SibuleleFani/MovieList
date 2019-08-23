using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using MovieList.Data.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace MovieList.Data.Database
{
    public class MovieDBContext : IMovieDBContext
    {
        private IMongoDatabase Database { get; set; }
        private readonly IMongoCollection<Movie> _movies;


        public MovieDBContext(string connectionString ,string databaseName, string movieCollectionName)
        {
            var mongoClient = new MongoClient(connectionString);
            Database = mongoClient.GetDatabase(databaseName);
           _movies = Database.GetCollection<Movie>(movieCollectionName);

        }

        public async Task AddAsync<T>(T entity) where T : Movie
        {
            await _movies.InsertOneAsync(entity);
        }

        public async Task<T> GetByIdAsync<T>(ObjectId id) where T : Movie
        {
            var data = await GetCollection<T>(typeof(T).Name).FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : Movie
        {
            IEnumerable<T> result = null;
            await Task.Run(() =>
            {
                result = Database.GetCollection<T>(typeof(T).Name).AsQueryable();
            });
            return result;
        }

        public async Task UpdateAsync<T>(T entity) where T : Movie
        {
            await GetCollection<T>(typeof(T).Name).ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.Id), entity);
        }

        public async Task RemoveAsync<T>(ObjectId id) where T : Movie
        {
            await Database.GetCollection<T>(typeof(T).Name).DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : Movie
        {
            T result = null;
            await Task.Run(() =>
            {
                result = GetCollection<T>(typeof(T).Name).AsQueryable().FirstOrDefault(predicate);
            });
            return result;
        }

        private IMongoCollection<Movie> GetCollection<Movie>(string movieCollectionName)
        {
            return Database.GetCollection<Movie>(movieCollectionName);
        }
    }
}
