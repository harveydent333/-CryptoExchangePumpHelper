using RecipientMessages.Infrastructure;
using RecipientMessages.Models;

namespace RecipientMessages.Builders
{
    public class ExchangeBuilder
    {
        private readonly BinanceHelper _binanceHelper;
        private readonly KucoinHelper _kucoinHelper;

        public ExchangeBuilder(BinanceHelper binanceHelper, KucoinHelper kucoinHelper)
        {
            _binanceHelper = binanceHelper;
            _kucoinHelper = kucoinHelper;
        }

        public Exchange CreateBinanceExchange()
        {
            var exchange = new Exchange
            {
                ExchangeType = ExchangeType.Binance,
                ExchangeHelper = _binanceHelper
            };

            return exchange;
        }

        public Exchange CreateKucoinExchange()
        {
            var exchange = new Exchange
            {
                ExchangeType = ExchangeType.Kucoin,
                ExchangeHelper = _kucoinHelper
            };

            return exchange;
        }
    }
}
