using OpenQA.Selenium;
using System.Threading;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using RecipientMessages.Models;

namespace RecipientMessages.Messengers
{
    public class TelegramHelper : BaseMessengerHelper
    {
        private ChromeDriver _drive;

        public TelegramHelper(ChromeDriver driver)
        {
            _drive = driver;
        }

        public override void Authorization(TextChat textChat)
        {
            _drive.Navigate().GoToUrl(ConfigurationManager.AppSettings["Environment.Telegram.Test"]); // меняем тут

            _drive.FindElements(By.CssSelector($"{ConfigurationManager.AppSettings["Css.Telegram.Phone"]}"))[0]
                .SendKeys(ConfigurationManager.AppSettings["Telegram.Phone"]);

            _drive.FindElements(By.TagName("my-i18n"))[0]
                .Click();

            Thread.Sleep(3000);

            _drive.FindElements(By.CssSelector("span[my-i18n=\'modal_ok\']"))[0]
                .Click();
        }
    }
}
