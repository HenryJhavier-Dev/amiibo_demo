using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AmiiboPedia.Helpers;
using AmiiboPedia.Model;
using Xamarin.Forms;

namespace AmiiboPedia.ViewModel
{
    public class MainPageVM : BaseViewModel
    {

        #region properties
        public ObservableCollection<Amiibo> AllAmiibos; 

        private ObservableCollection<Amiibo> amiibos;

        public ObservableCollection<Amiibo> Amiibos
        {
            get { return amiibos; }
            set {
                amiibos = value;
                OnPropertyChanged();
            }
        }

        private bool isEmpty;
        public bool IsEmpty
        {
            get { return isEmpty; }
            set {
                isEmpty = value;
                OnPropertyChanged();
            }
        }

        private string searchBarText;
        public string SearchBarText
        {
            get { return searchBarText; }
            set
            {
                searchBarText = value;

                if (searchBarText == null)
                {
                    searchBarText = string.Empty;
                }

                ChangeTextInSearchBar(value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
        public ICommand SearchCommand => new Command((text) => 
            SearchCommandExecute(text)
        );
        #endregion


        public async Task LoadAmiibos() {

            IsBusy  = true;

            var url = "https://www.amiiboapi.com/api/amiibo/";

            var httpHelper = new HttpHelper<Amiibos>();

            var amiibos    = await httpHelper.GetRestServiceDataAsync(url);

            Amiibos        = new ObservableCollection<Amiibo>(amiibos.amiibo);

            AllAmiibos     = new ObservableCollection <Amiibo>(amiibos.amiibo);

            IsBusy  = false;
            IsEmpty = false;

        }

        private void SearchCommandExecute(object text)
        {
           Console.WriteLine($"\nEl texto a filtrar es {text} \n");
        }

        // Filtrar string
        private void ChangeTextInSearchBar(string searchText)
        {

            Amiibos = new ObservableCollection<Amiibo>(

                AllAmiibos.Where(o => o.name.ToLower().
                    Contains(searchText.ToLower())).ToList());

            IsEmpty = Amiibos.Count() == 0 ? true : false;
        }
    }
}
