using codechallenge.Appllication.Movie;
using codechallenge.Infra.API;
using Xamarin.Forms;

namespace codechallenge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Service api = new Service();

            Navigation.PushModalAsync(new UpComingView(), true);
        }
    }
}
