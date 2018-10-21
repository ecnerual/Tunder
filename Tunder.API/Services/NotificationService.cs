using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonCode.Code.Builders;
using CommonCode.Messages;
using CommonCode.Messages.ViewModels;
using Data.Model;
using Tunder.API.Services;

namespace Tunder.API.Services
{
    public class NotificationService : INotificationService
    {
        public Task SendNotification(BaseMessage message)
        {
            throw new NotImplementedException();
        }

        public Task SendWelcomeMessage(User user)
        {
            var confirmEmail = new MessageBuilder<WelcomeMessage>(user, WelcomeMessage.From(user))
                .SendAsEmail("title")
                .GetInstance();

            return null;
        }
    }
}
