using RecipientMessages.Models;

namespace RecipientMessages.Messengers
{
    public abstract class BaseMessengerHelper
    {
        public MessengerType MessengerType { get; set; }

        public abstract void Authorization(TextChat textChat);
    }
}
