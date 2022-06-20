using AppShopping.Helpers.MVVM;
using AppShopping.Models;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("filmSerialized", "filmSerialized")]
    public class FilmDetailViewModel : BaseViewModel
    {
        public Film Film { get; set; }

        private string filmSerialized 
        { 
            set 
            {
                var decode = Uri.UnescapeDataString(value);
                var film = JsonConvert.DeserializeObject<Film>(decode);

                Film = film;
                OnPropertyChanged(nameof(Film));
            } 
        }
        public FilmDetailViewModel()
        {
        }
    }
}
