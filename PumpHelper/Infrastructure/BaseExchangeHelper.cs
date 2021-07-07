using RecipientMessages.Models;
using System;
using System.Threading.Tasks;
using static RecipientMessages.Program;

namespace RecipientMessages.Infrastructure
{
    public abstract class BaseExchangeHelper
    {
        public ExchangeType ExchangeType { get; set; }

        public abstract Task BuySymbolAsync(string coinName);

        public async Task Start(string coin)
        {
            try
            {
                await BuySymbolAsync(coin);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{_stopWatch.Elapsed}: {ex.Message}");
            }
        }
    }
}
