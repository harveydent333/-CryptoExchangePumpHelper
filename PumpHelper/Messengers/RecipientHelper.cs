using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using RecipientMessages.Models;
using System.Text.RegularExpressions;
using static RecipientMessages.Program;
using RecipientMessages.Constants;

namespace RecipientMessages.Messengers
{
    public class RecipientHelper
    {
        private readonly ChromeDriver _driver;
        private Pump _pump;

        public RecipientHelper(ChromeDriver driver)
        {
            _driver = driver;
        }

        public async Task FindLastMessageAsync(Pump pump)
        {
            _pump = pump;
            try
            {
                int count = _driver.FindElements(By.CssSelector(_pump.Messenger.MessageElement)).Count;
                int newCount = _driver.FindElements(By.CssSelector(_pump.Messenger.MessageElement)).Count;

                while (true)
                {
                    newCount = _driver.FindElements(By.CssSelector(_pump.Messenger.MessageElement)).Count;

                    if (newCount != count)
                    {
                        count = newCount;

                        string message = _driver.FindElements(By.CssSelector(_pump.Messenger.MessageElement))
                            .Last().Text;

                        await ProcessMessageAsync(message);

                        Console.WriteLine($"Общее время выполнения {_stopWatch.Elapsed}");
                        _stopWatch.Stop();
                        _stopWatch.Reset();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _stopWatch.Stop();
                _stopWatch.Reset();
            }
        }

        private async Task ProcessMessageAsync(string message)
        {
            _stopWatch.Start();

            if (message.Contains(_pump.TextChat.PartOfMessage) ||
                message.Contains(PartOfMessage.ReserveBTC) ||
                message.Contains(PartOfMessage.ReserveUSDT))
            {
                await ParseCoinNameAsync(message);
            }
            else
            {
                Console.WriteLine("Last message: " + message);
            }
        }

        private async Task ParseCoinNameAsync(string message)
        {
            var coin = Regex.Match(message, _pump.TextChat.RegexPattern).Groups[2].Value;
            var reserveBTC = Regex.Match(message, RegexPattern.ReserveBTC).Groups[1].Value;
            var reserveUSDT = Regex.Match(message, RegexPattern.ReserveUSDT).Groups[1].Value;

            if(!string.IsNullOrWhiteSpace(reserveBTC))
            {
                coin = reserveBTC;
            }else if(!string.IsNullOrWhiteSpace(reserveUSDT))
            {
                coin = reserveUSDT;
            }

            if (!string.IsNullOrWhiteSpace(coin))
            {
                await _pump.Exchange.ExchangeHelper.Start(coin);
            }
            else
            {
                Console.WriteLine("Last message: " + message);
            }
        }
    }
}
