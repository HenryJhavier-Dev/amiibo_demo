using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AmiiboPedia.ViewModel;
using Xamarin.Forms;

namespace AmiiboPedia.View
{
    public partial class MainPage : ContentPage
    {

        public MainPageVM ViewModel { get; set;  }

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

       
            ViewModel = new MainPageVM();
            this.BindingContext = ViewModel;

            await ViewModel.LoadAmiibos();



        }
    }
}
