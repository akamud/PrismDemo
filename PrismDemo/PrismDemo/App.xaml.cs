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

            NavigationService.NavigateAsync("ViewA?Title=TDC A/ViewB?Title=TDC B/ViewC?Title=TDC C/NavigationPage/MainPage/ViewA");
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
            Container.RegisterTypeForNavigation<MasterDetailPage>();
            Container.RegisterTypeForNavigation<ViewA>();
            Container.RegisterTypeForNavigation<ViewB>();
            Container.RegisterTypeForNavigation<ViewC>();
        }
    }
}
