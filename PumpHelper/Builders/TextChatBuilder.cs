using RecipientMessages.Constants;
using RecipientMessages.Models;
using System.Configuration;

namespace RecipientMessages.Builders
{
    public class TextChatBuilder
    {
        public TextChat Create_Mega_Pump_CryptoCurrency_Investment_Group()
        {
            var textChat = new TextChat
            {
                UrlAddress = ConfigurationManager.AppSettings["Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group"],
                PartOfMessage = PartOfMessage.Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group,
                RegexPattern = RegexPattern.Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group
            };

            return textChat;
        }
        public TextChat Create_Kucoin_Pump_Signal()
        {
            var textChat = new TextChat
            {
                UrlAddress = ConfigurationManager.AppSettings["Discord_Kucoin_Pump_Signal"],
                PartOfMessage = PartOfMessage.Discord_Kucoin_Pump_Signal,
                RegexPattern = RegexPattern.Discord_Kucoin_Pump_Signal
            };

            return textChat;
        }
        
        public TextChat Create_WallStreetBets_Kucoin_Pumps()
        {
            var textChat = new TextChat
            {
                UrlAddress = ConfigurationManager.AppSettings["Discord_WallStreetBets_Kucoin_Pumps"],
                PartOfMessage = PartOfMessage.Discord_WallStreetBets_Kucoin_Pumps,
                RegexPattern = RegexPattern.Discord_WallStreetBets_Kucoin_Pumps
            };

            return textChat;
        }

        public TextChat Create_Well_Played_Pumps()
        {
            var textChat = new TextChat
            {
                UrlAddress = ConfigurationManager.AppSettings["Discord_Well_Played_Pumps"],
                PartOfMessage = PartOfMessage.Discord_Well_Played_Pumps,
                RegexPattern = RegexPattern.Discord_Well_Played_Pumps
            };

            return textChat;
        }

        public TextChat Create_Yobit_Push_Singals()
        {
            var textChat = new TextChat
            {
                //UrlAddress = ConfigurationManager.AppSettings["Discord_Yobit_Push_Signals"],
                //PartOfMessage = PartOfMessage.Discord_Yobit_Push_Signals,
                //RegexPattern = RegexPattern.Discord_Yobit_Push_Signals
            };

            return textChat;
        }
    }
}
