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
    public void IAmLoggedInAsWithPassword(string username, string password)
    {
        var login = new LoginPage(_context.Driver!).GoTo();
        login.EnterUsername(username).EnterPassword(password);
        _productsPage = login.SubmitValid();
    }

    [When("I am on the products page")]
    public void IAmOnTheProductsPage()
    {
        _productsPage ??= new ProductsPage(_context.Driver!);
    }

    [Then("the products page should be loaded")]
    public void TheProductsPageShouldBeLoaded()
    {
        Assert.That(_productsPage!.IsLoaded(), Is.True);
    }

    [Then("there should be at least '(.*)' product listed")]
    public void ThereShouldBeAtLeastNProductListed(int count)
    {
        Assert.That(_productsPage!.GetInventoryItemsCount(), Is.GreaterThanOrEqualTo(count));
    }

    [Then("the banner should contain text '(.*)'")]
    public void TheBannerShouldContainText(string text)
    {
        Assert.That(_productsPage!.BannerContainsText(text), Is.True, $"Banner does not contain '{text}'");
    }

    [Then("the hamburger menu should be visible")]
    public void TheHamburgerMenuShouldBeVisible()
    {
        Assert.That(_productsPage!.IsHamburgerMenuVisible(), Is.True, "Hamburger menu is not visible");
        _productsPage.EnsureMenuOpen();
        Assert.That(_productsPage.IsMenuLinkVisibleWithoutToggling(SwagLabsTestAutomation.Pages.ProductsPage.AllItemsLink), Is.True, "All Items link is not visible in menu");
        Assert.That(_productsPage.IsMenuLinkVisibleWithoutToggling(SwagLabsTestAutomation.Pages.ProductsPage.AboutLink), Is.True, "About link is not visible in menu");
        Assert.That(_productsPage.IsMenuLinkVisibleWithoutToggling(SwagLabsTestAutomation.Pages.ProductsPage.ResetAppStateLink), Is.True, "Reset App State link is not visible in menu");
    }

    [Then("the shopping cart should be visible")]
    public void TheShoppingCartShouldBeVisible()
    {
        Assert.That(_productsPage!.IsShoppingCartVisible(), Is.True, "Shopping cart is not visible");
    }

    [Then("the sorting dropdown should be visible")]
    public void TheSortingDropdownShouldBeVisible()
    {
        Assert.That(_productsPage!.IsSortingDropdownVisible(), Is.True, "Sorting dropdown is not visible");
    }
}
