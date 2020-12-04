using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AmiiboPedia.Helpers
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        private bool isBusy { get; set; }

        public bool IsBusy
        {
            get => isBusy;

            set {
                isBusy = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /*protected void SetProperty<TData>(ref TData storage, TData value, [CallerMemberName] string propertyName = "")
        {
            if (storage.Equals(value))
                return;

            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}
