using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using codechallenge.Application.Genre;
using codechallenge.Application.Movie.Detail;
using codechallenge.Infra.API;
using codechallenge.Infra.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Extended;
using static Rg.Plugins.Popup.Services.PopupNavigation;

namespace codechallenge.Application.UpComing
{
    public class UpComingMovieViewModel : INotifyPropertyChanged 
    {
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
            Items = new InfiniteScrollCollection<UpComingMovieModel>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    var page = Items.Count / pageSize;
                    var items = await GetItems(page);
                    IsBusy = false;
                    return items;
                }
            };

            GetUpComingMovies();
        }

        public ICommand DetailMovieCommand => new Command<UpComingMovieModel>(async (upComingMovie) => await PushAsync(new DetailMovieView(upComingMovie), true));

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isBusy;
        private const Int16 pageSize = 20;
        private async Task GetUpComingMovies()
        {
            await LoadGenre();

            var items = await GetItems(1);

            Items.AddRange(items);
        }

        //todo: refactor (this method must be declared in other file...
        private async Task<IEnumerable<GenreModel>> LoadGenre()
        {
            var genreList = await new Service().GetList(new GenreModel());

            GlobalData.GetInstance().GenreCache.AddRange(genreList);

            return genreList;
        }

        private async Task<IEnumerable<UpComingMovieModel>> GetItems(int page) => await new Service().GetList(new UpComingMovieModel(), page);       
    }
}