using System.Collections.Generic;

namespace CommonCode.Messages
{
    public class BaseMessage
    {
        public IEnumerable<SendingInfo> Recipients { get; set; }
        public string Content { get; set; }
    }
}