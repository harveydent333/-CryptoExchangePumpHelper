using Binance.Net;
using Binance.Net.Objects.Spot;
using Kucoin.Net;
using Kucoin.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using RecipientMessages.Infrastructure;
using System;
using System.Configuration;
using System.Diagnostics;
using RecipientMessages.Messengers;
using RecipientMessages.Builders;

namespace RecipientMessages
{
    public class DI
    {
        public static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton(
                settings => new BinanceClientOptions
                {
                    ApiCredentials = new ApiCredentials(
                        key: ConfigurationManager.AppSettings["Binance.Key"],
                        secret: ConfigurationManager.AppSettings["Binance.Secret"]
                    )
                });

            services.AddSingleton(
                settings => new KucoinClientOptions
                {
                    ApiCredentials = new KucoinApiCredentials(
                        apiKey: ConfigurationManager.AppSettings["Kucoin.Key"],
                        apiSecret: ConfigurationManager.AppSettings["Kucoin.Secret"],
                        apiPassPhrase: ConfigurationManager.AppSettings["Kucoin.PassPhrase"]
                    )
                });

            services.AddSingleton<ChromeDriver>();
            services.AddSingleton<Stopwatch>();
            services.AddSingleton<BinanceClient>();
            services.AddSingleton<KucoinClient>();

            services.AddScoped<RecipientHelper>();
            
            services.AddSingleton<BinanceHelper>();
            services.AddSingleton<KucoinHelper>();

            services.AddSingleton<DiscordHelper>();
            services.AddSingleton<TelegramHelper>();

            services.AddSingleton<ExchangeBuilder>();
            services.AddSingleton<TextChatBuilder>();
            services.AddSingleton<MessengerBuilder>();
            services.AddSingleton<PumpBuilder>();

            return services.BuildServiceProvider();
        }
    }
}

