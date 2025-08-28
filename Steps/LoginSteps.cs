using TechTalk.SpecFlow;
using SwagLabsTestAutomation.Pages;
using SwagLabsTestAutomation.Drivers;
using NUnit.Framework;

namespace SwagLabsTestAutomation.Steps;

[Binding]
public class LoginSteps
{
    private readonly WebDriverContext _context;
    private LoginPage? _loginPage;
    private ProductsPage? _productsPage;
    private string? _errorMessage;

    public LoginSteps(WebDriverContext context)
    {
        _context = context;
    }

    [Given("I am on the login page")]
    public void IAmOnTheLoginPage()
    {
        _loginPage = new LoginPage(_context.Driver!).GoTo();
    }

    [Then("the login page elements should be visible")]
    public void TheLoginPageElementsShouldBeVisible()
    {
        Assert.That(_loginPage!.IsLoaded(), Is.True);
    }

    [When("I login as '(.*)' with password '(.*)'")]
    public void ILoginAsWithPassword(string username, string password)
    {
        _loginPage ??= new LoginPage(_context.Driver!);
        _loginPage.EnterUsername(username).EnterPassword(password);
        if (username == "locked_out_user")
            _loginPage = _loginPage.SubmitInvalid();
        else
            _productsPage = _loginPage.SubmitValid();
    }

    [Then("I should see the products page")]
    public void IShouldSeeTheProductsPage()
    {
        Assert.That(_productsPage!.IsLoaded(), Is.True);
    }

    [When("I logout")]
    public void ILogout()
    {
        _loginPage = _productsPage!.Logout();
    }

    [Then("I should see the login page")]
    public void IShouldSeeTheLoginPage()
    {
        Assert.That(_loginPage!.IsLoaded(), Is.True);
    }

    [Then("I should see an error message containing '(.*)'")]
    public void IShouldSeeAnErrorMessageContaining(string expected)
    {
        _errorMessage = _loginPage!.GetError();
        StringAssert.Contains(expected, _errorMessage);
    }
}
