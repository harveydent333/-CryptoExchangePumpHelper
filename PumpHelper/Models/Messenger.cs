using RecipientMessages.Messengers;

namespace RecipientMessages.Models
{
    public class Messenger
    {
        public MessengerType MessengerType { get; set; }

        public BaseMessengerHelper MessengerHelper { get; set; }

        public string MessageElement { get; set; }
    }
}
