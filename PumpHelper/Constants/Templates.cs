namespace RecipientMessages.Constants
{
    public class PartOfMessage
    {
        /// <summary>
        /// The coin we have picked to pump today is : #
        /// </summary>
        public static string Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group =>
            "The coin we have picked to pump today is : #";

        /// <summary>
        /// Coin is:
        /// </summary>
        public static string Discord_Kucoin_Pump_Signal => "Coin is:";

        /// <summary>
        /// The coin we have chosen is
        /// </summary>
        public static string Discord_Well_Played_Pumps =>
            "The coin we have chosen is";

        /// <summary>
        /// The coin we picked is
        /// </summary>
        public static string Discord_WallStreetBets_Kucoin_Pumps =>
            "The coin we picked is";

        /// <summary>
        /// /USDT
        /// </summary>
        public static string ReserveUSDT =>
            "/USDT";

        /// <summary>
        /// /BTC
        /// </summary>
        public static string ReserveBTC =>
            "/BTC";

        /// <summary>
        /// The coin we picked is
        /// </summary>
        public static string Telegram_Kucoin_Pump_Signal =>
            "The coin we picked is";
    }

    public static class RegexPattern
    {
        /// <summary>
        /// (.*)Coin is: ([\w]*)([\s\w]*)
        /// </summary>
        public static string Discord_Kucoin_Pump_Signal =>
            @"(.*)Coin is: ([\w]*)([\s\w]*)";

        /// <summary>
        /// (.*)The coin we have picked to pump today is : #([\w]*)([\s\w]*)
        /// </summary>
        public static string Discord_Binance_Mega_Pump_CryptoCurrency_Investment_Group =>
            @"(.*)The coin we have picked to pump today is : #([\w]*)([\s\w]*)";

        /// <summary>
        /// (.*)The coin we have chosen is\s([\w]*)([\s\w]*)
        /// </summary>
        public static string Discord_Well_Played_Pumps =>
            @"(.*)The coin we have chosen is\s([\w]*)([\s\w]*)";

        /// <summary>
        /// (.*)The coin we picked is\s([\w]*)/([\w\s]*)
        /// </summary>
        public static string Discord_WallStreetBets_Kucoin_Pumps =>
            @"(.*)The coin we picked is\s([\w]*)/([\w\s]*)";

        /// <summary>
        /// (*.)/USDT
        /// </summary>
        public static string ReserveUSDT =>
            @"(.*)/USDT";

        /// <summary>
        /// /BTC
        /// </summary>
        public static string ReserveBTC =>
            @"(.*)/BTC";

        /// <summary>
        /// (.*)The coin we picked is\s([\w]*)/([\w\s]*)
        /// </summary>
        public static string Telegram_Kucoin_Pump_Signal =>
            @"(.*)The coin we picked is\s([\w]*)/([\w\s]*)";
    }
}
