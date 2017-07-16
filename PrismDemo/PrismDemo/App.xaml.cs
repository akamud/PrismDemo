using Autofac;
using Prism.Autofac;
using Prism.Autofac.Forms;
using PrismDemo.Services;
using PrismDemo.ViewModels;
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

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            #region builder
            var builder = new ContainerBuilder();

            builder.RegisterType<MyService>().As<IMyService>();

            builder.Update(Container);
            #endregion

            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<HomePage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
        }
    }
}
