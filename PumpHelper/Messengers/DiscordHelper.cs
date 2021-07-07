using System.IO;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using RecipientMessages.Models;

namespace RecipientMessages.Messengers
{
    public class DiscordHelper : BaseMessengerHelper
    {
        private ChromeDriver _drive;

        public DiscordHelper(ChromeDriver driver)
        {
            _drive = driver;
        }

        public override void Authorization(TextChat textChat)
        {
            _drive.Navigate().GoToUrl(textChat.UrlAddress);

            _drive.FindElements(By.CssSelector($"{ConfigurationManager.AppSettings["Css.Discord.Email"]}"))[0]
                .SendKeys(ConfigurationManager.AppSettings["Discord.Email"]);

            _drive.FindElements(By.CssSelector($"{ConfigurationManager.AppSettings["Css.Discord.Password"]}"))[0]
                .SendKeys(File.ReadAllText("pass.txt")); 

            _drive.FindElements(By.CssSelector($"{ConfigurationManager.AppSettings["Css.Discord.ButtonLogin"]}"))[0]
                .Click();
        }
    }
}
