using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using PlaywrightUITests.Pages;
using static System.Net.Mime.MediaTypeNames;

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

        // Method to capture a screenshot
        protected async Task TakeScreenshotAsync(string screenshotName)
        {
            var testName = TestContext.CurrentContext.Test.Name;

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = $"Screenshots/{testName}_screenshot.png", // Dynamic test name
                FullPage = true // Capture full-page screenshot
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            // Close the browser after the test
            await Browser.CloseAsync();
        }

    }
}
