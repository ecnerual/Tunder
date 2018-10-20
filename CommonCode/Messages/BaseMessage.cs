using System.Collections.Generic;

namespace CommonCode.Messages
{
    public class BaseMessage
    {
        public ICollection<SendingInfo> Recipients { get; set; }
        public string Content { get; set; }
    }
}