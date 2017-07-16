using Moq;
using NUnit.Framework;
using PrismDemo.ViewModels;
using PrismDemo.Views;
using System;
using Xamarin.Forms;

namespace PrismDemo.UnitTests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        [Test]
        public void LoginCommandShouldShowNavigateToHomePage()
        {
            var navigationMock = new Mock<INavigation>();

            var vm = new MainPageViewModel(new HomePage());
            vm.Username = "Username";
            vm.Senha = "Senha";

            vm.LoginCommand.Execute(null);

            navigationMock.Verify(x => x.PushAsync(It.Is<Page>(p => p.GetType() == typeof(HomePage))), Times.Once());
        }
    }
}
