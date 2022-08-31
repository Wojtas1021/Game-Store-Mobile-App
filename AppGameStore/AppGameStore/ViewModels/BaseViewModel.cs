using AppGameStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppGameStore.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        // odpowiada za ustawienie property i invoke property
        protected bool SetProperty<T>(ref T backingStore, T value,//backingtore zmienna w tle 'title' , value wartość, którą chcemy zastąpić backingstore
            [CallerMemberName] string propertyName = "",//propertyName = Title
            Action onChanged = null)// Action referencja do funkcji, która nie pobiera parametrów i nie zwraca niczego
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) //porównujemy dane, jeżeli dane są takie same to zwracamy false
                return false;
            // jezeli dane są inne, zamieniamy na nowe
            backingStore = value;
            onChanged?.Invoke();//wywołuje funkcji za pomocą invoke delegacja
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        // invokuje event jw. 
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));//przekazujemy nazwę property i argumnet
        }
        #endregion
    }
}
