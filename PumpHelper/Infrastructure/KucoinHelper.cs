using System;
using Kucoin.Net;
using Kucoin.Net.Objects;
using System.Threading.Tasks;
using static RecipientMessages.Program;

namespace RecipientMessages.Infrastructure
{
    public class KucoinHelper : BaseExchangeHelper
    {
        private KucoinClient _client;

        public KucoinHelper(KucoinClient client)
        {
            _client = client;
        }

        public override async Task BuySymbolAsync(string coin)
        {
            var ourUsdt = 13.02M;
            var symbol = _client.Get24HourStats(coin + "-USDT");
            var symbolPrice = symbol.Data.Last;

            if (symbolPrice > 2)
                throw new Exception("Error Price");

            var newQuantity = (int)decimal.Truncate(ourUsdt / (symbolPrice + symbolPrice * 0.10M).Value); //0.1 % занижаем цену

            await _client.PlaceOrderAsync(coin + "-USDT", KucoinOrderSide.Buy, KucoinNewOrderType.Market, quantity: newQuantity);

            int c = 2; // 1, - 0 символ 1 , 1 - символ ,
            int needToRound = 6;

            var priceChars = symbol.Data.Last.ToString().ToCharArray();

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

            var newPrice = (symbolPrice + symbolPrice * 0.06M).Value; // % прибыли

            newPrice = Math.Round(newPrice, roundDigitals);

                var resultSell = await _client.PlaceOrderAsync(
                    symbol: symbol.Data.Symbol,
                    side: KucoinOrderSide.Sell,
                    type: KucoinNewOrderType.Limit,
                    timeInForce: KucoinTimeInForce.GoodTillCancelled,
                    quantity: newQuantity,
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
            

            Console.WriteLine($"Общее время выполнения {_stopWatch.Elapsed}");
        }
    }
}