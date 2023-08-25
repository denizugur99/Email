using MassTransit;
using Model;
using Org.BouncyCastle.Security;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

using static Org.BouncyCastle.Math.EC.ECCurve;

internal class OrderConsumer : IConsumer<Order>
{
    private readonly ILogger<OrderConsumer> _logger;
    private readonly IEmailService _emailService;
    public OrderConsumer(ILogger<OrderConsumer> logger, IEmailService emailService)
    {

        _logger = logger;
        _emailService = emailService;
    }

    public async Task Consume(ConsumeContext<Order> context)
    {
   
        await Console.Out.WriteLineAsync(context.Message.Name);
        _emailService.SendEmail(context.Message.Name, "denougur0@gmail.com");
        _logger.LogInformation($"got the message {context.Message.Name} sending E-mail");
        

    }
    

}