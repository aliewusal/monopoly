using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace monopoly
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class MainViewModel : BaseViewModel
    {
        public Command OpenSettingsCommand { get; set; }
        public MainViewModel()
        {
            OpenSettingsCommand = new Command(async obj => await openSettings(obj));
        }
        private async Task openSettings(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Settings());
        }
        
    }
}
