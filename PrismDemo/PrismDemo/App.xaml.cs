using Autofac;
using Prism.Autofac;
using Prism.Autofac.Forms;
using PrismDemo.Services;
using PrismDemo.Views;
using Xamarin.Forms;

namespace PrismDemo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //NavigationService.NavigateAsync("MainPage");

            DependencyService.Register<IMyService, MyService>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<HomePage>();
        }
    }
}
