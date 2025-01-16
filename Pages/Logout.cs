using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITests.Pages
{
    public class Logout
    {
        private static IPage _page;

        public Logout(IPage page)
        {
            _page = page;

        }

        private ILocator _btnLogout => _page.Locator("i.icon-2x.icon-signout:text('Logout')");


        public async Task ClickLogout() => await _btnLogout.ClickAsync();

    }
}
