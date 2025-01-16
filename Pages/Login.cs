using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITests.Pages
{
    public class Login
    {
        private static IPage _page;

        public Login(IPage page) 
        {
           _page = page;
        
        }

        private ILocator _lnkFormAuthentication => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Form Authentication" });
        private ILocator _txtUserName => _page.GetByLabel("username");
        private ILocator _txtPassword => _page.GetByLabel("password");
        private ILocator _btnLogin => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "login" });

        public async Task ClickFormAuthentication() => await _lnkFormAuthentication.ClickAsync();

        public async Task EnterUsername(string userName) => await _txtUserName.FillAsync(userName);
        public async Task EnterPassword(string password) => await _txtPassword.FillAsync(password);


        public async Task ClickLogin() => await _btnLogin.ClickAsync();

    }
}
