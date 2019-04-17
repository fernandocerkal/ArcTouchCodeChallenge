using codechallenge.Application.UpComing;
using Rg.Plugins.Popup.Pages;

namespace codechallenge.Application.Movie.Detail
{
    public partial class DetailMovieView : PopupPage
    {
        public DetailMovieView(UpComingMovieModel selectedUpComingMovie)
        {
            BindingContext = new DetailMovieViewModel(selectedUpComingMovie);

            InitializeComponent();
        }
    }
}