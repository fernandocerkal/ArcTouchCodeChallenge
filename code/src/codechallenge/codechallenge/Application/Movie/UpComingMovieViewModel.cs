using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using codechallenge.Application.Genre;
using codechallenge.Infra.API;
using Xamarin.Forms.Extended;

namespace codechallenge.Application.Movie
{
    public class UpComingMovieViewModel : INotifyPropertyChanged //where T : class, IBaseModel 
    {
        private bool     _isBusy;
        private IService api = null;
        private const Int16 pageSize = 20;


        private async Task GetUpComingMovies()
        {
            var items = api.GetList(new UpComingMovieModel(), 1).GetAwaiter().GetResult().Results;

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
            List<GenreModel> genres = api.GetList(new GenreModel(), null).GetAwaiter().GetResult().Results as List<GenreModel>;

            Items = new InfiniteScrollCollection<UpComingMovieModel>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    var page = Items.Count / pageSize;
                    var items = api.GetList(new UpComingMovieModel(), page).GetAwaiter().GetResult().Results;
                    IsBusy = false;
                    return items;
                }
            };

            GetUpComingMovies();
        }      

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}