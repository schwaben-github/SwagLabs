using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SwagLabsTestAutomation;

[Binding]
public sealed class Hooks
{
    private readonly WebDriverContext _context;

    public Hooks(WebDriverContext context)
    {
        _context = context;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        // Optional: deactivate headless mode
        options.AddArgument("--headless=new");
        options.AddArgument("--disable-credential-services");
        options.AddArgument("--incognito");
        options.AddArgument("--disable-features=PasswordManagerEnabled,PasswordCheck");
        options.AddArgument("--disable-blink-features=AutomationControlled");
        options.AddArgument("--no-default-browser-check");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-popup-blocking");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--disable-save-password-bubble");
        var tempProfile = Path.Combine(Path.GetTempPath(), $"chrome-profile-{Guid.NewGuid()}");
        options.AddArgument($"--user-data-dir={tempProfile}");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        _context.Driver = new ChromeDriver(options);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _context.Driver?.Quit();
        _context.Driver?.Dispose();
        _context.Driver = null;
    }
}