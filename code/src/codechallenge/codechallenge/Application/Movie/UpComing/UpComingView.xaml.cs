using Xamarin.Forms;

namespace codechallenge.Application.UpComing
{
    public partial class UpComingView : ContentPage
    {
        public UpComingView()
        {
            InitializeComponent();

            BindingContext = new UpComingMovieViewModel();
        }
    }
}