using System.ComponentModel;
using System.Windows.Input;
using codechallenge.Application.UpComing;
using Xamarin.Forms;

namespace codechallenge.Application.Main
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand UpComingCommand => new Command(async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UpComingView(), true));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

