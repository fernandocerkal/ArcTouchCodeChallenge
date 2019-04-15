using codechallenge.Application.UpComing;
using Xamarin.Forms;

namespace codechallenge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Navigation.PushModalAsync(new UpComingView(), true);
        }
    }
}