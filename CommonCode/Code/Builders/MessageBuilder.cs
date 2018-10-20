using System;
using System.Collections.Generic;
using System.Text;
using CommonCode.Messages;
using Data.Model;

namespace CommonCode.Code.Builders
{
    public class MessageBuilder : IBuilder<BaseMessage>
    {
        private readonly User _user;
        private readonly BaseMessage _baseMessage;

        public MessageBuilder(User user)
        {
            _user = user;
            _baseMessage = new BaseMessage();
        }

        public MessageBuilder SendEmail(string title)
        {
            _baseMessage.Recipients.Add(new EmailSendingInfo(_user.Email, title));
            return this;
        }

        public BaseMessage GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
