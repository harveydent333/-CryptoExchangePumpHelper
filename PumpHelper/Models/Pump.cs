namespace RecipientMessages.Models
{
    public class Pump
    {
        public string PumpName { get; set; }

        public Exchange Exchange { get; set; }

        public Messenger Messenger { get; set; }

        public TextChat TextChat { get; set; }
    }
}
