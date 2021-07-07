using RecipientMessages.Constants;
using RecipientMessages.Models;

namespace RecipientMessages.Builders
{
    public class PumpBuilder
    {
        private ExchangeBuilder _exchangeBuilder;
        private MessengerBuilder _messengerBuilder;
        private TextChatBuilder _textChatBuilder;

        public PumpBuilder(ExchangeBuilder exchangeBuilder, MessengerBuilder messengerBuilder, TextChatBuilder textChatBuilder)
        {
            _exchangeBuilder = exchangeBuilder;
            _messengerBuilder = messengerBuilder;
            _textChatBuilder = textChatBuilder;
        }

        public Pump CreatePump(PumpType pumpType)
        {
            switch (pumpType)
            {
                case PumpType.Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group:
                    {
                        return CreateMegaPumpCryptoCurrencyInvestmentGroup();
                    }
                case PumpType.Discord_Kucoin_Pump_Signal:
                    {
                        return CreateKucoinPumpSignal();
                    }
                case PumpType.Discord_WallStreetBets_Kucoin_Pumps:
                    {
                        return CreateWallStreetBetsKucoinPumps();
                    }
                case PumpType.Discord_Well_Played_Pumps:
                    {
                        return CreateWellPlayedPumps();
                    }
                case PumpType.Discord_Yobit_Push_Signals:
                    {
                        return CreateYobitPushSignals();
                    }
                default:
                    {
                        System.Console.WriteLine("Incorrect pump number");
                        return null;
                    }
            }
        }

        public Pump CreateMegaPumpCryptoCurrencyInvestmentGroup()
        {
            var messenger = _messengerBuilder.CreateDiscordMessenger();
            var exchange = _exchangeBuilder.CreateBinanceExchange();
            var textChat = _textChatBuilder.Create_Mega_Pump_CryptoCurrency_Investment_Group();

            var pump = new Pump
            {
                PumpName = PumpName.Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group,
                Messenger = messenger,
                Exchange = exchange,
                TextChat = textChat
            };

            return pump;
        }

        public Pump CreateKucoinPumpSignal()
        {
            var messenger = _messengerBuilder.CreateDiscordMessenger();
            var exchange = _exchangeBuilder.CreateKucoinExchange();
            var textChat = _textChatBuilder.Create_Kucoin_Pump_Signal();

            var pump = new Pump
            {
                PumpName = PumpName.Discord_Kucoin_Pump_Signal,
                Messenger = messenger,
                Exchange = exchange,
                TextChat = textChat
            };

            return pump;
        }

        public Pump CreateWellPlayedPumps()
        {
            var messenger = _messengerBuilder.CreateDiscordMessenger();
            var exchange = _exchangeBuilder.CreateKucoinExchange();
            var textChat = _textChatBuilder.Create_Well_Played_Pumps();

            var pump = new Pump
            {
                PumpName = PumpName.Discord_Well_Played_Pumps,
                Messenger = messenger,
                Exchange = exchange,
                TextChat = textChat
            };

            return pump;
        }

        public Pump CreateWallStreetBetsKucoinPumps()
        {
            var messenger = _messengerBuilder.CreateDiscordMessenger();
            var exchange = _exchangeBuilder.CreateKucoinExchange();
            var textChat = _textChatBuilder.Create_WallStreetBets_Kucoin_Pumps();

            var pump = new Pump
            {
                PumpName = PumpName.Discord_WallStreetBets_Kucoin_Pumps,
                Messenger = messenger,
                Exchange = exchange,
                TextChat = textChat
            };

            return pump;
        }

        public Pump CreateYobitPushSignals()
        {
            var messenger = _messengerBuilder.CreateDiscordMessenger();
            var exchange = _exchangeBuilder.CreateKucoinExchange();
            var textChat = _textChatBuilder.Create_Yobit_Push_Singals();

            var pump = new Pump
            {
                PumpName = PumpName.Discord_Yobit_Push_Signals,
                Messenger = messenger,
                Exchange = exchange,
                TextChat = textChat
            };

            return pump;
        }
    }
}
