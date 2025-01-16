using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightUITests.Pages;

namespace PlaywrightUITests.Utils
{
    public class BaseTest
    {
        protected IPage Page;
        protected IBrowser Browser;
        protected IPlaywright PlaywrightInstance;
        protected Login LoginPage;
        protected Secure SecurePage;

        [SetUp]
        public async Task Setup()
        {
            // Playwright setup
            PlaywrightInstance = await Playwright.CreateAsync();

            // Browser setup (Chromium in this case)
            Browser = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true for headless mode
            });

            // Create a new page and navigate to the application URL
            Page = await Browser.NewPageAsync();
            await NavigateToPageAsync("https://the-internet.herokuapp.com/");

            // Instantiate page objects (Login and Secure)
            LoginPage = new Login(Page);
            SecurePage = new Secure(Page);
        }

        // Method to navigate to a specific page
        protected async Task NavigateToPageAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Close the browser after the test
            await Browser.CloseAsync();
        }

    }
}
