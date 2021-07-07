using Binance.Net;
using Binance.Net.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using static RecipientMessages.Program;

namespace RecipientMessages.Infrastructure
{
    public class BinanceHelper : BaseExchangeHelper
    {
        private BinanceClient _client;
        private decimal _outBtcBalance;
        private const decimal PROFIT = 0.2M;

        public BinanceHelper(BinanceClient client)
        {
            _client = client;
            _outBtcBalance = _client.General.GetAccountInfo().Data.Balances.FirstOrDefault(b => b.Asset == "BTC").Total;
        }

        public override async Task BuySymbolAsync(string coinName)
        {
            _outBtcBalance = 0.00044742M;
            var symbol = await _client.Spot.Market.GetPriceAsync(coinName + "BTC");
            var symbolPrice = symbol.Data.Price;

            var priceChars = symbol.Data.Price.ToString().ToCharArray();

            int c = 2; // 1, - 0 символ 1 , 1 - символ ,
            int needToRound = 6;

            var newQuentity = (int)decimal.Truncate(_outBtcBalance / (symbolPrice + symbolPrice * 0.1M)); // 0.10 занижаем кол-во монет, говорим наш баланс -10%

            if (newQuentity == 0)
            {
                throw new Exception("Error: невозможно купить 0 монет");
            }

            var result = await _client.Spot.Order.PlaceTestOrderAsync(symbol.Data.Symbol, OrderSide.Buy, OrderType.Market, quantity: newQuentity);
            if (result.Success)
            {
                Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Order.Market Buy - Success");
                Console.WriteLine($"{_stopWatch.Elapsed}: Был куплен {symbol.Data.Symbol} по цене {symbolPrice} в количестве {newQuentity} на сумму BTC {newQuentity * symbolPrice}," +
                    $" хватило баланса: {newQuentity * symbolPrice <= _outBtcBalance } биткоина осталось: {_outBtcBalance - newQuentity * symbolPrice}");
            }
            else
            {
                Console.WriteLine($"{_stopWatch.Elapsed} : Coin:  {symbol.Data.Symbol} , Order.Market Buy - Error Code: ");
            }

            while (c <= 6)
            {
                if (priceChars[c] != '0')
                {
                    needToRound = c;
                    break;
                }
                c++;
            }

            var roundDigitals = 6;

            switch (needToRound)
            {
                case 2:
                    {
                        roundDigitals = 3;
                        break;
                    }
                case 3:
                    {
                        roundDigitals = 4;
                        break;
                    }
                case 4:
                    {
                        roundDigitals = 5;
                        break;
                    }
                case 5:
                    {
                        roundDigitals = 6;
                        break;
                    }
                case 6:
                    {
                        roundDigitals = 7;
                        break;
                    }
            }

            symbol = await _client.Spot.Market.GetPriceAsync(coinName + "BTC");
            symbolPrice = symbol.Data.Price;

            var newPrice = (symbolPrice + symbolPrice * PROFIT); // % прибыли
            newPrice = Math.Round(newPrice, roundDigitals);

            var onePart = (int)decimal.Truncate(newQuentity / 2);

            if (onePart > 1)
            {
                var result2 = await _client.Spot.Order.PlaceTestOrderAsync(
                    symbol: symbol.Data.Symbol,
                    side: OrderSide.Sell,
                    type: OrderType.Limit,
                    timeInForce: TimeInForce.GoodTillCancel,
                    quantity: onePart,
                    price: newPrice
                );

                var result3 = await _client.Spot.Order.PlaceTestOrderAsync(
                    symbol: symbol.Data.Symbol,
                    side: OrderSide.Sell,
                    type: OrderType.Limit,
                    timeInForce: TimeInForce.GoodTillCancel,
                    quantity: newQuentity - onePart,
                    price: newPrice
                );

                if (result2.Success)
                {
                    Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Side: Sell, Order:Limit - Success");
                }
                else
                {
                    Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Side: Buy, Order:Limit - Error Code: {result2.Error.Code} Message:{result2.Error.Message}");
                }

                if (result3.Success)
                {
                    Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Side: Sell, Order:Limit - Success");
                }
                else
                {
                    Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Side: Buy, Order:Limit - Error Code: {result3.Error.Code} Message:{result3.Error.Message}");
                }
            }
            else
            {
                var resultSell = await _client.Spot.Order.PlaceTestOrderAsync(
                    symbol: symbol.Data.Symbol,
                    side: OrderSide.Sell,
                    type: OrderType.Limit,
                    timeInForce: TimeInForce.GoodTillCancel,
                    quantity: newQuentity,
                    price: newPrice
                );

                if (resultSell.Success)
                {
                    Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Side: Sell, Order:Limit - Success");
                }
                else
                {
                    Console.WriteLine($"{_stopWatch.Elapsed}: Coin: {symbol.Data.Symbol}, Side: Buy, Order:Limit - Error Code: {resultSell.Error.Code} Message:{resultSell.Error.Message}");
                }

            }

        }
    }
}
