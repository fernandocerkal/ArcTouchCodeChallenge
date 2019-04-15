using System;
using codechallenge.Application.Genre;
using codechallenge.Infra.Cache;
using Newtonsoft.Json;

namespace codechallenge.Application.UpComing
{
    public class UpComingMovieModel : BaseModel
    {

        public UpComingMovieModel() : base(@"movie/upcoming")
        { 
        
        }

        [JsonProperty("vote_count")]
        public Int32?   VoteCont    { get; set; } = 0;
        [JsonProperty("id")]
        public Int32?   UpComingMovideId  { get; set; } = null;
        [JsonProperty("video")]
        public Boolean? Video       { get; set; } = false;
        [JsonProperty("vote_average")]
        public Double?   VoteAverage { get; set; } = 0;
        [JsonProperty("title")]
        public String   Title       { get; set; } = String.Empty;
        [JsonProperty("popularity")]
        public Double?  Popularity  { get; set; } = null;
        [JsonProperty("poster_path")]
        public String   PosterPath  { get; set; } = String.Empty;
        [JsonProperty("original_language")]
        public String   OriginalLanguage { get; set; } = String.Empty;
        [JsonProperty("original_title")]
        public String   OriginalTitle { get; set; } = String.Empty;
        [JsonProperty("genre_ids")]
        public Int32[]  GenreIds         { get; set; }
        [JsonProperty("backdrop_path")]
        public String   BackDropPath { get; set; } = String.Empty;
        [JsonProperty("overview")]
        public String   Overview { get; set; } = String.Empty;
        [JsonProperty("adult")]
        public Boolean? Adult { get; set; } = null;
        [JsonProperty("release_date")]
        public String   ReleaseDate { get; set; } = String.Empty;

        private GenreModel[] genreModels;
        public GenreModel[] FilterGenreModel(ICache<GenreModel> modelCache)
        {
            // todo: Filter Genre Model
            if (genreModels == null) genreModels = new GenreModel[0];

            return genreModels;
        }

        public string FullVirtualPathOfImage => $"https://image.tmdb.org/t/p/w185_and_h278_bestv2/{PosterPath ?? BackDropPath}";
    }
}
