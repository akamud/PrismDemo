using PrismDemo.ViewModels;
using Xamarin.Forms;

namespace PrismDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new MainPageViewModel(this, Navigation);
        }
    }
}
