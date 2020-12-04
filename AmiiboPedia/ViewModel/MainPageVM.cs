using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Amiibo> amiibos;

        public ObservableCollection<Amiibo> Amiibos
        {
            get => amiibos;
            set {
                amiibos = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
        public ICommand SearchCommand => new Command((text) => SearchCommandExecute(text));
        #endregion

        public async Task LoadAmiibos() {

            IsBusy = true;

            var url = "https://www.amiiboapi.com/api/amiibo/";

            var httpHelper = new HttpHelper<Amiibos>();

            var amiibos    = await httpHelper.GetRestServiceDataAsync(url);

            Amiibos        = new ObservableCollection<Amiibo>(amiibos.amiibo);

            IsBusy = false; 

        }

        // Filtrar string
        private void SearchCommandExecute(object text)
        {
            Console.WriteLine($"\nEl texto a filtrar es {text} \n");

            Amiibos.Clear();
            Amiibos = objectDetails.Where(item => item.NameCatalog.ToLower().Contains(searchText.ToLower())).ToList();

            if (ListBusinessCatalog.Count() == 0) { EmptyStateBool = true; }
            else { EmptyStateBool = false; }
        }
    }
}
