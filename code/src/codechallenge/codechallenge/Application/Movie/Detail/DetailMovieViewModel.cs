using codechallenge.Application.UpComing;

namespace codechallenge.Application.Movie.Detail
{
    public class DetailMovieViewModel
    {
        public DetailMovieViewModel(UpComingMovieModel selectedUpComingMovie)
        {
            this.SelectedUpComingMovie = selectedUpComingMovie;
        }

        public UpComingMovieModel SelectedUpComingMovie { get; internal set; }
    }
}
