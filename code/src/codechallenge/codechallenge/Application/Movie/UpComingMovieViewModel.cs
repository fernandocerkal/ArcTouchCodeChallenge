using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
            var items = await this.api.GetList(new UpComingMovieModel(), 1);

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


        }

        public UpComingMovieViewModel(IService api)
        {
            this.api = api;

            Items = new InfiniteScrollCollection<UpComingMovieModel>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    var page = Items.Count / pageSize;
                    var items = await api.GetList(new UpComingMovieModel(), page);
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
