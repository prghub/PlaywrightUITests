using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITests.Pages
{
    public class Secure
    {
        private static IPage _page;

        public Secure(IPage page)
        {
            _page = page;

        }

        private ILocator _btnLogout => _page.Locator("i.icon-2x.icon-signout:text('Logout')");
        private ILocator _subheaderLocator => _page.Locator("h4.subheader:text('Welcome to the Secure Area. When you are done click logout below.')");
        private ILocator _flashMessageLocator => _page.Locator("div#flash.flash.success[data-alert]");



        public async Task ClickLogout() => await _btnLogout.ClickAsync();

        public async Task<bool> WelcomeText() => await _subheaderLocator.IsVisibleAsync();

        public async Task<string> FlashMessageText()
        {
            return await _flashMessageLocator.InnerTextAsync();
        }
    }
}
