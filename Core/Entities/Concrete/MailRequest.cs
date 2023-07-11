namespace Core.Entities.Concrete
{
    public class MailRequest : IEntity
    {

        public string ReceiverName { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
