using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MovieList.Common.Enum;

namespace MovieList.Data.Model
{
   public class MovieDTO : Movie
    {
        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public Genre Genre { get; set; }
    }
}
