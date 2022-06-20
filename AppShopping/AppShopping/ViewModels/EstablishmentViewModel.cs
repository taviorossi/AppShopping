using AppShopping.Helpers.MVVM;
using AppShopping.Libraries.Enums;
using AppShopping.Models;
using AppShopping.Services;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public abstract class EstablishmentViewModel : BaseViewModel
    {
        /*
        * MVVM - View <-> ViewModel <-> Model
        * - Commands: Ações > Métodos.
        * - Bindings: Vinculos > Propriedades
        * - Notifications
        * 
        * View(Lojas-Stores): Entry(Text=Binding SearchWord, Mode=TwoWay)
        * ViewModel: string SearchWord
        * Entry - Text=Renner-(ViewModel-SearchWord: Renner)
        * 
        * Notificação: INotifyPropertyChanged, MessageCenter(Code Behind)
        */

        public String SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }
        private List<Establishment> _establishments;
        public List<Establishment> Establishments
        {
            get
            {
                return _establishments;
            }
            set
            {
                SetProperty(ref _establishments, value);
            }
        }
        private List<Establishment> _allEstablishments;

        public ICommand DetailCommand { get; set; }

        private EstablishmentType _establishmentType;
        public EstablishmentViewModel(EstablishmentType establishmentType)
        {
            _establishmentType = establishmentType;
            SearchCommand = new MvvmHelpers.Commands.Command(Search);
            DetailCommand = new MvvmHelpers.Commands.Command<Establishment>(Detail);

            var allEstablishments = new EstablishmentService().GetEstablishments(); //30 = L20 + R10
            var allStores = allEstablishments.Where(a => a.Type == _establishmentType).ToList();

            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }

        private void Detail(Establishment establishment)
        {
            String establishmentSerialized = JsonConvert.SerializeObject(establishment);
            Shell.Current.GoToAsync($"establishment/detail?establishmentSerialized={Uri.EscapeDataString(establishmentSerialized)}");
        }
    }
}
