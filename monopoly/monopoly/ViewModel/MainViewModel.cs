using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

using monopoly.View;
using monopoly.Model;
using System.Collections.ObjectModel;
using System.Threading;

namespace monopoly.ViewModel
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
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Friend> Friends { get; set; }
        public Command OpenSettingsCommand { get; set; }
        public Command OpenLobbyCommand { get; set; }
        public Command OpenGameCommand { get; set; }
        public Command BackCommand { get; set; }
        public Command OpenProfileCommand { get; set; }
        public Command OpenFriendsCommand { get; set; }
        public INavigation Navigation { get; set; }
        public MainViewModel(INavigation navigation)
        {
            Rooms = new ObservableCollection<Room>
            {
                new Room { Name = "Bill:", Count = "1/4", imgPrivate="lock.png"},
                new Room { Name = "Tom:", Count = "4/4", imgPrivate=""},
                new Room { Name = "Alice:", Count = "2/4", imgPrivate="lock.png"},
                new Room { Name = "Alices:", Count = "2/4", imgPrivate="lock.png"},
                new Room { Name = "Alicedd:", Count = "2/4", imgPrivate="lock.png"},
                new Room { Name = "Alicexxx:", Count = "2/4", imgPrivate="lock.png"},
                new Room { Name = "Aliceiuxx:", Count = "2/4", imgPrivate="lock.png"},
                new Room { Name = "фффффффффф:", Count = "1/4", imgPrivate="lock.png"},
                new Room { Name = "WWWWWWWWWW:", Count = "1/4", imgPrivate="lock.png"},
                new Room { Name = "щщщщщщщщщщ:", Count = "1/4", imgPrivate="lock.png"},
                new Room { Name = "Aliceasdtglg14:", Count = "0/4", imgPrivate="lock.png"},
                new Room { Name = "Aliceasdtglg14asdasd:", Count = "0/4", imgPrivate="lock.png"},
                new Room { Name = "Aliceasdtglg14Aliceasdtglg14:", Count = "0/4", imgPrivate="lock.png"},
            };

            Friends = new ObservableCollection<Friend>
            {
                new Friend { Name = "Bill;", id = "#123456", imgAvatar="", isOfferToFriend = true},
                new Friend { Name = "Tom;", id = "#654321", imgAvatar="car.png", isOfferToFriend = false},
                new Friend { Name = "Alice;", id = "#123654", imgAvatar="car.png", isOfferToFriend = true},
                new Friend { Name = "Alices;", id = "#654321", imgAvatar="car.png", isOfferToFriend = true},
                new Friend { Name = "ass;", id = "#999999", imgAvatar="", isOfferToFriend = false},
                new Friend { Name = "erwcv;", id = "#333333", imgAvatar="car.png", isOfferToFriend = true},
                new Friend { Name = "jkcnhyhss;", id = "#090909", imgAvatar="", isOfferToFriend = false},
            };

            Friends = new ObservableCollection<Friend>(Friends.OrderBy(i => !i.isOfferToFriend));

            this.Navigation = navigation;
            OpenSettingsCommand = new Command(async obj => await openSettings(obj));
            OpenLobbyCommand = new Command(async obj => await openLobby(obj));
            OpenGameCommand = new Command(async obj => await openGame(obj));
            BackCommand = new Command(async obj => await back(obj));
            OpenFriendsCommand = new Command(async obj => await openFriends(obj));
            OpenProfileCommand = new Command(async obj => await openProfile(obj));
        }
        private async Task openSettings(object obj)
        {
            await Navigation.PushAsync(new Settings());
        }
        private async Task openLobby(object obj)
        {
            await Navigation.PushAsync(new Lobby()); //Application.Current.MainPage.Navigation.PushAsync(new Lobbys());
        }
        private async Task openGame(object obj)
        {
            await Navigation.PushAsync(new Game());
        }
        private async Task back(object obj)
        {
            await Navigation.PopAsync();
        }
        private async Task openFriends(object obj)
        {
            await Navigation.PushAsync(new Friends());
        }
        private async Task openProfile(object obj)
        {
            await Navigation.PushAsync(new Auth());
        }

    }
}
