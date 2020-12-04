using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AmiiboPedia.Helpers;
using AmiiboPedia.Model;

namespace AmiiboPedia.ViewModel
{
    public class MainPageVM : BaseViewModel
    {
        public ObservableCollection<Amiibo> Amiibos { get; set; }

        public async Task LoadAmiibos() {

            var url = "https://www.amiiboapi.com/api/character/";

            var httpHelper = new HttpHelper<Amiibos>();

            var amiibos = await httpHelper.GetRestServiceDataAsync(url);

            Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);


        }

    }
}
