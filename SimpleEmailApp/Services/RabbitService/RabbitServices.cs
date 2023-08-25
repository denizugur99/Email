//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Text;


//namespace SimpleEmailApp.Services.RabbitService
//{
//    public class RabbitServices
//    {

     


//        public string Receiver()
//        {
//            ConnectionFactory factory = new();
//            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
//            factory.ClientProvidedName = "Rabbit Receiver";

//            IConnection cnn = factory.CreateConnection();

//            IModel channel = cnn.CreateModel();

//            string exchangeName = "DemoExchange";
//            string routingKey = "demo-routing-key";
//            string queueName = "DemoQueue";
//            string message = " ";
//            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
//            channel.QueueDeclare(queueName, false, false, false, null);
//            channel.QueueBind(queueName, exchangeName, routingKey, null);
//            channel.BasicQos(0, 1, false);

//            var consumer = new EventingBasicConsumer(channel);
//            consumer.Received += (sender, args) =>
//            {
//                var body = args.Body.ToArray();

//                message = Encoding.UTF8.GetString(body); ;

//                Console.WriteLine($"Message received {message}");

//                channel.BasicAck(args.DeliveryTag, false);

                
//            };

//            string consumerTag = channel.BasicConsume(queueName, false, consumer);
            

//            channel.BasicCancel(consumerTag);

//            channel.Close();

//            cnn.Close();


//            return message;

//        }

//    }
//}
