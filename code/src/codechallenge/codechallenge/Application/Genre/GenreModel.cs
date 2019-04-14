using System;
namespace codechallenge.Application.Genre
{
    public class GenreModel : BaseModel 
    {
        public GenreModel() : base(@"genre/movie/list")
        { 
        
        }

        public Int32 GenreId { get; set; }

        public String Name { get; set; }
    }
}
