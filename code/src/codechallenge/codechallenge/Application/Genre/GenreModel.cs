using System;
using Newtonsoft.Json;

namespace codechallenge.Application.Genre
{
    public class GenreModel : BaseModel 
    {
        public GenreModel() : base(@"genre/movie/list", "genres")
        { 
        
        }

        [JsonProperty("id")]
        public Int32 GenreId { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
