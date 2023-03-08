using DigitalMedia.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DigitalMedia.StepDefinitions
{
    [Binding]
    public sealed class MusicArtistSteps : MusicArtistPage
    {
        private IWebDriver driver;

        public MusicArtistSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I access CapitalFm <URL>")]
        public void GivenIAccessCapitalFmURL()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        [When(@"I accept consent cookies")]
        public void WhenIAcceptConsentCookies()
        {
            
            try
            {
                IWebElement iframe = driver.FindElement(By.Id(Iframepg));
                driver.SwitchTo().Frame(iframe);
                driver.FindElement(By.XPath(ConsentAcceptpg)).Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

      [Then(@"Check ""([^""]*)"" is playing now or avaialble in recent play")]
        public void ThenCheckIsPlayingNowOrAvaialbleInRecentPlay(string artist)
        {
            
            Thread.Sleep(5000);

            var nowPlayingArtist = driver.FindElement(By.XPath(NowPlayingArtistpg));
            if (nowPlayingArtist.Text.Contains(artist))
            {
                Console.WriteLine("Music playing now is " + artist);
            }
            else
            {
               var recentlyPlayed = driver.FindElement(By.XPath(SeeMorepg));
               recentlyPlayed.Click();

                var lastPlayed = driver.FindElement(By.XPath(LastPlayedSongpg));
                if (lastPlayed.Text.Contains(artist))
                {
                    try
                    {
                        var artistElement2 = artistSearch1 + artist + artistSearch2;
                        IWebElement timePlayed = driver.FindElement(By.XPath(artistElement2));
                        Console.WriteLine(artist + " music was played lastly at : " + timePlayed.Text);

                        DateTime firstTime = DateTime.Now;
                        DateTime secondTime = DateTime.Parse(timePlayed.Text);

                        TimeSpan timeAgo = firstTime.Subtract(secondTime);
                        Console.WriteLine("The music wass played " + timeAgo + " hours/mins ago");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception : " + ex);
                    }
                }
                else
                {
                    Console.WriteLine("The artist " + artist + " music is not played recently");
                }
            }
        }



    }
}