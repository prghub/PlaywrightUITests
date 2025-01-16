using Microsoft.Playwright;


namespace PlaywrightUITests
{
    public class FileUpload
    {
        [Test]
        public async Task FileUploadTest()
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
            await page.GotoAsync("https://the-internet.herokuapp.com/upload");

            // Get the file path for upload (ensure the file exists)
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.txt"); // Make sure sample.txt exists in the working directory

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            await page.SetInputFilesAsync("input[type='file-upload']", filePath);
            // Submit the form
            await page.ClickAsync("button[type='submit']");

            // Wait for the success message that indicates the file was uploaded
            var uploadSuccessLocator = page.Locator("h3:has-text('File Uploaded!')");

            // Wait for the success message to appear
            await uploadSuccessLocator.WaitForAsync();

            // Verify if the message is displayed
            var isVisible = await uploadSuccessLocator.IsVisibleAsync();
            if (isVisible)
            {
                Console.WriteLine("File uploaded successfully!");
            }
            else
            {
                Console.WriteLine("File upload failed.");
            }

            // Close the browser
            await browser.CloseAsync();

        }
    }
}
