using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagLabsTestAutomation.Drivers;

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
        options.AddArgument("--start-maximized");
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