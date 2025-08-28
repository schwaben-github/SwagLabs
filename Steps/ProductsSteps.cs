using TechTalk.SpecFlow;
using SwagLabsTestAutomation.Pages;
using SwagLabsTestAutomation.Drivers;
using NUnit.Framework;

namespace SwagLabsTestAutomation.Steps;

[Binding]
public class ProductsSteps
{
    private readonly WebDriverContext _context;
    private ProductsPage? _productsPage;

    public ProductsSteps(WebDriverContext context)
    {
        _context = context;
    }

    [Given("I am logged in as '(.*)' with password '(.*)'")]
    public void GivenIAmLoggedInAsWithPassword(string username, string password)
    {
        var login = new LoginPage(_context.Driver!).GoTo();
        login.EnterUsername(username).EnterPassword(password);
        _productsPage = login.SubmitValid();
    }

    [When("I am on the products page")]
    public void WhenIAmOnTheProductsPage()
    {
        _productsPage ??= new ProductsPage(_context.Driver!);
    }

    [Then("the products page should be loaded")]
    public void ThenTheProductsPageShouldBeLoaded()
    {
        Assert.That(_productsPage!.IsLoaded(), Is.True);
    }

    [Then("there should be at least '(.*)' product listed")]
    public void ThenThereShouldBeAtLeastNProductListed(int count)
    {
        Assert.That(_productsPage!.GetInventoryItemsCount(), Is.GreaterThanOrEqualTo(count));
    }
}
