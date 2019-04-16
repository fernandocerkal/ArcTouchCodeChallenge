using System.Windows.Input;
using codechallenge.Application.UpComing;
using Xamarin.Forms;

namespace codechallenge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public ICommand UpComingCommand => new Command(async () => await Navigation.PushModalAsync(new UpComingView(), true));
    }
}