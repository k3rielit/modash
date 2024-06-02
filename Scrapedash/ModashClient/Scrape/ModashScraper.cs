using Microsoft.Playwright;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModashClient.Scrape {

    public class ModashScraper : IDisposable {

        public Random RandomInstance { get; private set; } = new Random();
        public IPlaywright? PlaywrightInstance { get; private set; }
        public IBrowser? BrowserInstance { get; private set; }
        public IBrowserContext? BrowserContext { get; private set; }

        public async Task InitAsync() {
            PlaywrightInstance = await Playwright.CreateAsync();
            BrowserInstance = await PlaywrightInstance.Chromium.LaunchAsync(new() {
                Headless = true,
            });
            BrowserContext = await BrowserInstance.NewContextAsync();
        }

        public async Task<string?> LoginAsync(string email, string password) {
            if(BrowserContext == null) return null;
            // Open login page
            var page = await BrowserContext.NewPageAsync();
            await page.GotoAsync("https://marketer.modash.io/login/marketer");
            // Get login elements
            var emailInput = page.Locator("#email-address");
            var passwordInput = page.Locator("input[type='password']");
            var LoginButton = page.Locator("text=Log in");
            // Simulate user interaction
            await emailInput.FocusAsync();
            await emailInput.FillAsync(email);
            await Task.Delay(RandomInstance.Next(951, 1782));
            await passwordInput.FocusAsync();
            await passwordInput.FillAsync(password);
            await Task.Delay(RandomInstance.Next(951, 1782));
            await LoginButton.ClickAsync();
            // Wait for a logged in page, or fail after a while
            var discovery = page.Locator("h1", new() { HasTextString = "Discovery"}).First;
            await discovery.WaitForAsync(new() {
                Timeout = 10000,
            });
            if(discovery == null) return null;
            // Extract and combine cookies
            var cookies = await BrowserContext.CookiesAsync(new List<string>() { "https://marketer.modash.io" });
            return string.Join("; ", cookies.Select(cookie => $"{cookie.Name}={cookie.Value}"));
        }

        public async Task DisposeAsync() {
            if(BrowserContext != null) {
                await BrowserContext.CloseAsync();
            }
            if(BrowserInstance != null) {
                await BrowserInstance.CloseAsync();
            }
            PlaywrightInstance?.Dispose();
        }

        public void Dispose() {
            Task.Run(DisposeAsync).GetAwaiter().GetResult();
            GC.SuppressFinalize(this);
        }

    }

}
