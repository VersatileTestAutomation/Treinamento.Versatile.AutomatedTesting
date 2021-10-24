using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Treinamento.Versatile.UIAutomatedTesting.Configurations.Factories
{
    public class DriverFactory
    {
        public IWebDriver _driver;

        public DriverFactory() { }

        public IWebDriver CreateDriver(string browser = null)
        {
            browser ??= "chrome";

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    var chromeOptions = new ChromeOptions { PageLoadStrategy = PageLoadStrategy.Eager };
                    return new ChromeDriver(chromeOptions);
                case "FIREFOX":
                    return new FirefoxDriver();
                case "IE":
                    var optionsIE = new InternetExplorerOptions { EnableNativeEvents = false, IgnoreZoomLevel = true, PageLoadStrategy = PageLoadStrategy.Eager };
                    return new InternetExplorerDriver(optionsIE);
                case "EDGE":
                    var optionsEdge = new EdgeOptions { UseChromium = true, PageLoadStrategy = PageLoadStrategy.Eager };
                    return new EdgeDriver(optionsEdge);
                default:
                    throw new ArgumentException($"Browser não implementado: {browser}");
            }
        }

        public void Navigate(string url) => _driver.Navigate().GoToUrl(url);

        public IWebDriver Driver() => _driver;

        public void Maximize() => _driver.Manage().Window.Maximize();

        public void Refresh() => _driver.Navigate().Refresh();

        public void Close() => _driver.Close();

        public void Quit() => _driver.Quit();

    }
}
