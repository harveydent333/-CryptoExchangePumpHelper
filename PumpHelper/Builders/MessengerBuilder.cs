using RecipientMessages.Messengers;
using RecipientMessages.Models;
using System.Configuration;

namespace RecipientMessages.Builders
{
    public class MessengerBuilder
    {
        private readonly DiscordHelper _discordHelper;
        private readonly TelegramHelper _telegramHelper;

        public MessengerBuilder(DiscordHelper discordHelper, TelegramHelper telegramHelper)
        {
            _discordHelper = discordHelper;
            _telegramHelper = telegramHelper;
        }

        public Messenger CreateDiscordMessenger()
        {
            var messenger = new Messenger
            {
                MessengerType = MessengerType.Discord,
                MessengerHelper = _discordHelper,
                MessageElement =  ConfigurationManager.AppSettings["Css.Discord.MessageElement"]
        };

            return messenger;
        }

        public Messenger CreateTelegramMessenger()
        {
            var messenger = new Messenger
            {
                MessengerType = MessengerType.Telegram,
                MessengerHelper = _telegramHelper,
                MessageElement =  ConfigurationManager.AppSettings["Css.Telegram.MessageElement"]
            };

            return messenger;
        }

    }
}
