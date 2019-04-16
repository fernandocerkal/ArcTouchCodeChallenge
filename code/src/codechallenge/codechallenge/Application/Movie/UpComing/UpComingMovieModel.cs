using System;
using System.Collections.Generic;
using System.Linq;
using codechallenge.Infra.Helper;
using Newtonsoft.Json;

namespace codechallenge.Application.UpComing
{
    public class UpComingMovieModel : BaseModel
    {

        public UpComingMovieModel() : base(@"movie/upcoming", "results")
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

        public IEnumerable<string> GenderList => GlobalData.GetInstance()?.GenreCache.List().Where(w => GenreIds.Contains(w.GenreId)).Select(s=>s.Name);

        public string Genders => string.Join(", ", GenderList);

        public string FullVirtualPathOfImage => $"https://image.tmdb.org/t/p/w185_and_h278_bestv2/{PosterPath ?? BackDropPath}";
    }
}