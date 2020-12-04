﻿using System;
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
    }
}
