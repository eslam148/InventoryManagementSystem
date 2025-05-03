using System;
using System.Collections.Generic;
using System.Linq;
 using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using MediatR;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace InventoryManagementSystem.Application.Features.Products.Notification
{
    public class LowStockThresholdNotificationEventHandler:INotificationHandler<LowStockThresholdNotificationEvent>
    {
        public async Task Handle(LowStockThresholdNotificationEvent notification, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Eslam", "islam12476794@gmail.com"));
            message.To.Add(new MailboxAddress("Hassan", notification.Email));
            message.Subject = "Low Stock product";
            message.Body = new TextPart("plain")
            {
                Text = $"Low Stock product Name ={notification.Message}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("islam12476794@gmail.com", "ngto vuoj exuc lrtf");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
             
        }
    }
    
}
