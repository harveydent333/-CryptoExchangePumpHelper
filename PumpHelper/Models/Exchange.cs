using RecipientMessages.Infrastructure;

namespace RecipientMessages.Models
{
    public class Exchange
    {
        public ExchangeType ExchangeType { get; set; }

        public BaseExchangeHelper ExchangeHelper { get; set; }
    }
}
