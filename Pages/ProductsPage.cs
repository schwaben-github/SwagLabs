using OpenQA.Selenium;

namespace SwagLabsTestAutomation.Pages;

public class ProductsPage : BasePage
{
    private static readonly By ProductsTitle = By.CssSelector("span.title");
    private static readonly By BurgerMenuButton = By.Id("react-burger-menu-btn");
    private static readonly By LogoutLink = By.Id("logout_sidebar_link");
    private static readonly By InventoryItems = By.CssSelector(".inventory_item");

    public ProductsPage(IWebDriver driver) : base(driver) { }

    public bool IsLoaded()
    {
        return WaitVisible(ProductsTitle).Text.Equals("Products", StringComparison.OrdinalIgnoreCase);
    }

    public int GetInventoryItemsCount()
    {
        return Driver.FindElements(InventoryItems).Count;
    }

    public LoginPage Logout()
    {
        WaitClickable(BurgerMenuButton).Click();
        WaitClickable(LogoutLink).Click();
        return new LoginPage(Driver);
    }
}
