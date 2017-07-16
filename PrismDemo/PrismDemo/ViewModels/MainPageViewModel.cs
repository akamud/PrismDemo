using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismDemo.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly Page _page;
        private readonly INavigation _navigation;

        public MainPageViewModel(Page page, INavigation navigation)
        {
            _page = page;
            _navigation = navigation;
        }

        private Command loginCommand;
        public Command LoginCommand => loginCommand = loginCommand ?? new Command(async () => await Login()
            , CanLogin);

        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Senha))
            {
                await _page.DisplayAlert("Atenção", "Preencha login e senha", "OK");
            }
            else
            {
                await _navigation.PushAsync(new HomePage());
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Senha);
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                LoginCommand.ChangeCanExecute();
            }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                LoginCommand.ChangeCanExecute();
            }
        }
    }
}
