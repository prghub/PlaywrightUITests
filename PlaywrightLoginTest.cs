using Microsoft.Playwright;
using PlaywrightUITests.Pages;
using PlaywrightUITests.Utils;

namespace PlaywrightUITests
{
    public class PlaywrightLoginTest :BaseTest
    {
        [Test]
        public async Task Login()
        {
            await LoginPage.ClickFormAuthentication();
            await LoginPage.EnterUsername("tomsmith");
            await LoginPage.EnterPassword("SuperSecretPassword!");
            await LoginPage.ClickLogin();

            // Take a screenshot before assertion
            await TakeScreenshotAsync("login_flash_message_screenshot");

            var flashMessageText = await SecurePage.FlashMessageText();

            Assert.That(flashMessageText, Is.EqualTo(" You logged into a secure area!\n×"));
        }

        [Test]
        public async Task LogOut()
        {
            await LoginPage.ClickFormAuthentication();
            await LoginPage.EnterUsername("tomsmith");
            await LoginPage.EnterPassword("SuperSecretPassword!");
            await LoginPage.ClickLogin();


            await SecurePage.ClickLogout();

            // Take a screenshot before assertion
            await TakeScreenshotAsync("logout_flash_message_screenshot");

            var flashMessageText = await SecurePage.FlashMessageText();

            Assert.That(flashMessageText, Is.EqualTo(" You logged out of the secure area!\n×"));
        }
    }
}