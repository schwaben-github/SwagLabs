using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabsTestAutomation.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement WaitVisible(By by)
    {
        return Wait.Until(d =>
        {
            try
            {
                var el = d.FindElement(by);
                return el.Displayed ? el : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        })!;
    }

    protected IWebElement WaitClickable(By by)
    {
        return Wait.Until(d =>
        {
            try
            {
                var el = d.FindElement(by);
                return (el.Displayed && el.Enabled) ? el : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        })!;
    }

    protected bool WaitUrlContains(string fragment)
        => Wait.Until(d => d.Url.Contains(fragment, StringComparison.OrdinalIgnoreCase));
}
