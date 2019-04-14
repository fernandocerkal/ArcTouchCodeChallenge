using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using codechallenge.Infra.API;

using Xamarin.Forms.Extended;

using System.Windows.Input;

using codechallenge.Application.Movie.Detail;
using static Rg.Plugins.Popup.Services.PopupNavigation;
using Xamarin.Forms;

namespace codechallenge.Application.UpComing
{
    public class UpComingMovieViewModel : INotifyPropertyChanged //where T : class, IBaseModel 
    {
        private bool _isBusy;
        private IService api = null;
        private const Int16 pageSize = 20;


        private async Task GetUpComingMovies()
        {
            var items = GetItems(1);

            Items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public InfiniteScrollCollection<UpComingMovieModel> Items { get; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public UpComingMovieViewModel()
        {
            //todo: inject dependency
            api = new Service();

            //todo: refactor (this var must be declared in other file...
            //List<GenreModel> genres = api.GetList(new GenreModel(), null).GetAwaiter().GetResult().Results as List<GenreModel>;

            Items = new InfiniteScrollCollection<UpComingMovieModel>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    var page = Items.Count / pageSize;
                    var items = GetItems(page);
                    IsBusy = false;
                    return items;
                }
            };

            GetUpComingMovies();
        }

        //public ICommand DetailMovieCommand => new Command<UpComingMovieModel>((upComingMovie) => PushAsync(new DetailMovieView() /*{ SelectedUpComingMovie = upComingMovie }*/));
        public ICommand DetailMovieCommand => new Command<UpComingMovieModel>(async (upComingMovie) => await PushAsync(new DetailMovieView() /*{ SelectedUpComingMovie = upComingMovie }*/, true));


        private IEnumerable<UpComingMovieModel> GetItems(int page) => api.GetList(new UpComingMovieModel(), page).GetAwaiter().GetResult().Results;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}