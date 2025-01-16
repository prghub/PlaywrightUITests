using Microsoft.Playwright;
using PlaywrightUITests.Pages;


namespace PlaywrightUITests
{
    public class PlaywrightCrossBrowserTests
    {
        [Test]
        public async Task TestCrossBrowser()
        {
            var playwright = await Playwright.CreateAsync();

            // Test on Chromium
            var chromium = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await chromium.NewPageAsync();
            await page.GotoAsync("https://the-internet.herokuapp.com/");
            var title = await page.TitleAsync();
            Assert.That(title, Is.EqualTo("The Internet"));
            await chromium.CloseAsync();

            // Test on Firefox
            var firefox = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            page = await firefox.NewPageAsync();
            await page.GotoAsync("https://the-internet.herokuapp.com/");
            title = await page.TitleAsync();
            Assert.That(title, Is.EqualTo("The Internet"));
            await firefox.CloseAsync();

            // Test on WebKit (Safari)
            var webkit = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            page = await webkit.NewPageAsync();
            await page.GotoAsync("https://the-internet.herokuapp.com/");
            title = await page.TitleAsync();
            Assert.That(title, Is.EqualTo("The Internet"));
            await webkit.CloseAsync();
        }
    }
}
