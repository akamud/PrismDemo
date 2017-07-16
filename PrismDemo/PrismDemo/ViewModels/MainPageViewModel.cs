using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismDemo.Services;
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
        private readonly IMyService _myService;

        public MainPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService, IMyService myService)
        {
            _pageDialogService = pageDialogService;
            _myService = myService;
            _navigationService = navigationService;
        }

        private DelegateCommand loginCommand;
        public DelegateCommand LoginCommand => loginCommand = loginCommand ?? new DelegateCommand(async () => await Login()
            , CanLogin)
            .ObservesProperty(() => Senha).ObservesProperty(() => Username);

        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Senha))
            {
                await _pageDialogService.DisplayAlertAsync("Atenção", "Preencha login e senha", "OK");
            }
            else
            {
                await _navigationService.NavigateAsync("HomePage?Title=TDC SP 2017");
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
            set { SetProperty(ref _username, value); }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { SetProperty(ref _senha, value); }
        }

        private readonly IPageDialogService _pageDialogService;
        private readonly INavigationService _navigationService;
    }
}
