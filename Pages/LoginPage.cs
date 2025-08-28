using OpenQA.Selenium;

namespace SwagLabsTestAutomation.Pages;

public class LoginPage : BasePage
{
    private static readonly string PageUrl = "https://www.saucedemo.com/";

    private static readonly By UsernameInput = By.Id("user-name");
    private static readonly By PasswordInput = By.Id("password");
    private static readonly By LoginButton = By.Id("login-button");
    private static readonly By ErrorMessage = By.CssSelector("h3[data-test='error']");
    private static readonly By LoginLogo = By.ClassName("login_logo");
    private static readonly By BotLogo = By.ClassName("bot_column");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public LoginPage GoTo()
    {
        Driver.Navigate().GoToUrl(PageUrl);
        return this;
    }

    public bool IsLoaded()
    {
        return WaitVisible(UsernameInput).Displayed
               && WaitVisible(PasswordInput).Displayed
               && WaitVisible(LoginButton).Displayed;
    }

    public LoginPage EnterUsername(string username)
    {
        var el = WaitVisible(UsernameInput);
        el.Clear();
        el.SendKeys(username);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        var el = WaitVisible(PasswordInput);
        el.Clear();
        el.SendKeys(password);
        return this;
    }

    public ProductsPage SubmitValid()
    {
        WaitClickable(LoginButton).Click();
        return new ProductsPage(Driver);
    }

    public LoginPage SubmitInvalid()
    {
        WaitClickable(LoginButton).Click();
        return this;
    }

    public string GetError()
    {
        try
        {
            return WaitVisible(ErrorMessage).Text.Trim();
        }
        catch
        {
            return string.Empty;
        }
    }
}
