using System.Threading.Tasks;
using codechallenge.Appllication.Movie;
using Xamarin.Forms;

namespace codechallenge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Task.Delay(2000);

            Navigation.PushModalAsync(new UpComingView());
        }
    }
}
