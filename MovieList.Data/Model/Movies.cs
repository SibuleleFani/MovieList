using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MovieList.Data.Model
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
