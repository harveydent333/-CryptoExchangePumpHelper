using System;
using System.Diagnostics;
using System.Threading.Tasks;
using RecipientMessages.Models;
using RecipientMessages.Builders;
using RecipientMessages.Constants;
using RecipientMessages.Messengers;
using Microsoft.Extensions.DependencyInjection;

namespace RecipientMessages
{
    internal class Program
    {
        private static RecipientHelper _recipientHelper;
        private static PumpBuilder _pumpBuilder;
        public static Stopwatch _stopWatch;

        private static void Initialize()
        {
            var serviceProvider = DI.BuildServiceProvider();
            IServiceScope scope = serviceProvider.CreateScope();

            _recipientHelper = scope.ServiceProvider.GetService<RecipientHelper>();
            _pumpBuilder = scope.ServiceProvider.GetService<PumpBuilder>();
            _stopWatch = scope.ServiceProvider.GetService<Stopwatch>();

            Console.Clear();
        }

        private static async Task StartAsync(Pump pump)
        {
            try
            {
                await _recipientHelper.FindLastMessageAsync(pump);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task Main(string[] args)
        {
            Initialize();

            bool isSelectedPump = false;
            Pump pump = null;

            string helloMessage = "What is pump will you use?\n";

            helloMessage += $"1. {PumpName.Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group}\n";
            helloMessage += $"2. {PumpName.Discord_Kucoin_Pump_Signal}\n";
            helloMessage += $"3. {PumpName.Discord_WallStreetBets_Kucoin_Pumps}\n";
            helloMessage += $"4. {PumpName.Discord_Well_Played_Pumps}\n";
            helloMessage += $"5. {PumpName.Discord_Yobit_Push_Signals}\n";

            Console.WriteLine(helloMessage);

            while (!isSelectedPump)
            {
                var pumpNames = Enum.GetValues(typeof(PumpType));

                if (!int.TryParse(Console.ReadLine(), out int pumpNumber) && pumpNumber <= pumpNames.Length)
                {
                    Console.WriteLine("Incorrect value");
                    continue;
                }

                var pumpName = pumpNames.GetValue(pumpNumber - 1);

                Enum.TryParse(pumpName.ToString(), out PumpType pumpType);

                pump = _pumpBuilder.CreatePump(pumpType);

                if (pump != null)
                {
                    isSelectedPump = true;
                }
            }

            Console.Clear();

            pump.Messenger.MessengerHelper.Authorization(pump.TextChat);

            while (true)
            {
                await StartAsync(pump);
            }
        }
    }
}
