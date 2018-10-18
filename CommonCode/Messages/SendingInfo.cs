namespace CommonCode.Messages
{
    public abstract class SendingInfo
    {
        public MessageType MessageType { get; protected set; }

        public SendingInfo(MessageType messageType)
        {
            MessageType = messageType;
        }
    }
}