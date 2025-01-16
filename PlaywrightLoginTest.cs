using Microsoft.Playwright;
using PlaywrightUITests.Pages;

namespace PlaywrightUITests
{
    public class PlaywrightLoginTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Login ()
        {
            //Playwright
            using var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://the-internet.herokuapp.com/");

            var loginPage = new Login(page);
            await loginPage.ClickFormAuthentication();
            await loginPage.EnterUsername("tomsmith");
            await loginPage.EnterPassword("SuperSecretPassword!");
            await loginPage.ClickLogin();

            var logoutPage = new Logout(page);
            await logoutPage.ClickLogout();



        }
    }
}