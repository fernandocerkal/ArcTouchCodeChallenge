using Xamarin.Forms;

namespace codechallenge.Application.Main
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }      
    }
}