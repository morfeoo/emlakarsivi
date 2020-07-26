using System.Threading.Tasks;
using RemDijital.EmlakTakip.Models.TokenAuth;
using RemDijital.EmlakTakip.Web.Controllers;
using Shouldly;
using Xunit;

namespace RemDijital.EmlakTakip.Web.Tests.Controllers
{
    public class HomeController_Tests: EmlakTakipWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}