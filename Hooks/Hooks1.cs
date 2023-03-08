using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DigitalMedia.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;

        public Hooks1(IObjectContainer container)
        {
            _container= container;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {
           var driver =  _container.Resolve<IWebDriver>();
           if(driver != null) 
            {
                driver.Quit();
            }
        }
    }
}