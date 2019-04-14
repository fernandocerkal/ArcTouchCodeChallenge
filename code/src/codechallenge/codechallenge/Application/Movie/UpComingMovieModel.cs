using System;
using codechallenge.Application.Genre;
using codechallenge.Infra.Cache;

namespace codechallenge.Application.Movie
{
    public class UpComingMovieModel : BaseModel
    {

        public UpComingMovieModel() : base(@"movie/upcoming")
        { 
        
        }

        public Int32?   VoteCont    { get; set; } = 0;
        public Int32?   UpComingMovideId  { get; set; } = null;
        public Boolean? Video       { get; set; } = false;
        public Int32?   VoteAverage { get; set; } = 0;
        public String   Title       { get; set; } = String.Empty;
        public Double?  Popularity  { get; set; } = null;
        public String   PosterPath  { get; set; } = String.Empty;
        public String   OriginalLanguage { get; set; } = String.Empty;
        public String   OriginalTitle { get; set; } = String.Empty;
        public Int32[]  GenreIds         { get; set; }
        public String   BackDropPath { get; set; } = String.Empty;
        public String   Overview { get; set; } = String.Empty;
        public Boolean? Adult { get; set; } = null;
        public String   ReleaseDate { get; set; } = String.Empty;

        private GenreModel[] genreModels;
        public GenreModel[] FilterGenreModel(ICache<GenreModel> modelCache)
        {
            // todo: Filter Genre Model
            if (genreModels == null) genreModels = new GenreModel[0];

            return genreModels;
        }

    }
}
