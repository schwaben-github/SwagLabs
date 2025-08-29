using OpenQA.Selenium;

namespace SwagLabsTestAutomation.Pages;

public class ProductsPage : BasePage
{
    private static readonly By ProductsTitle = By.CssSelector("span.title");
    private static readonly By BurgerMenuButton = By.Id("react-burger-menu-btn");
    private static readonly By BurgerMenuPanel = By.CssSelector(".bm-menu");
    private static readonly By LogoutLink = By.Id("logout_sidebar_link");
    private static readonly By InventoryItems = By.CssSelector(".inventory_item");
    private static readonly By SwagLabsBanner = By.ClassName("app_logo");
    private static readonly By ShoppingCart = By.Id("shopping_cart_container");
    private static readonly By SortingDropdown = By.ClassName("product_sort_container");
    public static readonly By AllItemsLink = By.Id("inventory_sidebar_link");
    public static readonly By AboutLink = By.Id("about_sidebar_link");
    public static readonly By ResetAppStateLink = By.Id("reset_sidebar_link");

    public ProductsPage(IWebDriver driver) : base(driver) { }

    private void DismissChromeWarningIfPresent()
    {
        try
        {
            var closeBtn = Driver.FindElement(By.CssSelector("button[aria-label='Close'], .close, .modal-close"));
            if (closeBtn.Displayed)
            {
                try
                {
                    closeBtn.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", closeBtn);
                }
            }
        }
        catch (NoSuchElementException) { /* Popup not present */ }
    }

    public bool IsLoaded()
    {
        return WaitVisible(ProductsTitle).Text.Equals("Products", StringComparison.OrdinalIgnoreCase);
    }

    public int GetInventoryItemsCount()
    {
        return Driver.FindElements(InventoryItems).Count;
    }

    public bool BannerContainsText(string text)
    {
        return WaitVisible(SwagLabsBanner).Text.Contains(text, StringComparison.OrdinalIgnoreCase)
            || WaitVisible(ProductsTitle).Text.Contains(text, StringComparison.OrdinalIgnoreCase);
    }

    public bool IsHamburgerMenuVisible() => WaitVisible(BurgerMenuButton).Displayed;
    public bool IsShoppingCartVisible() => WaitVisible(ShoppingCart).Displayed;
    public bool IsSortingDropdownVisible() => WaitVisible(SortingDropdown).Displayed;

    public bool IsMenuLinkVisible(By linkBy)
    {
        DismissChromeWarningIfPresent();
        bool menuOpen = false;
        try
        {
            var menuPanel = Driver.FindElement(BurgerMenuPanel);
            menuOpen = menuPanel.Displayed && menuPanel.GetCssValue("transform").Contains("1"); // open state
        }
        catch (NoSuchElementException) { menuOpen = false; }
        if (!menuOpen)
        {
            WaitClickable(BurgerMenuButton).Click();
        }
        var visible = WaitVisible(linkBy).Displayed;
        return visible;
    }

    private bool IsMenuOpen()
    {
        try
        {
            var menuPanel = Driver.FindElement(BurgerMenuPanel);
            return menuPanel.Displayed && menuPanel.GetCssValue("transform").Contains("1");
        }
        catch (NoSuchElementException) { return false; }
    }

    public void EnsureMenuOpen()
    {
        DismissChromeWarningIfPresent();
        if (!IsMenuOpen())
        {
            WaitClickable(BurgerMenuButton).Click();
        }
    }

    public bool IsMenuLinkVisibleWithoutToggling(By linkBy)
    {
        try
        {
            return WaitVisible(linkBy).Displayed;
        }
        catch (NoSuchElementException) { return false; }
    }

    public LoginPage Logout()
    {
        DismissChromeWarningIfPresent();
        EnsureMenuOpen();
        WaitClickable(LogoutLink).Click();
        return new LoginPage(Driver);
    }
}
