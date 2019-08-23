using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Data.Model
{
    public class MovieDatabaseSettings : IMovieDatabaseSettings
    {
       public string MovieCollectionName { get; set; }
       public string ConnectionString { get; set; }
       public string DatabaseName { get; set; }
    }

    public interface IMovieDatabaseSettings
    {
       string MovieCollectionName { get; set; }
       string ConnectionString { get; set; }
       string DatabaseName { get; set; }
    }
}
