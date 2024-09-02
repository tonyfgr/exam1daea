using System;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        string brokerList = "ec2-3-91-157-108.compute-1.amazonaws.com:9092"; // Dirección de tu broker de Kafka
        string topic = "products-topic"; // Nombre del topic en Kafka

        var config = new ConsumerConfig
        {
            GroupId = "product-consumer-group",
            BootstrapServers = brokerList,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
        {
            consumer.Subscribe(topic);

            Console.WriteLine("Esperando mensajes...");
            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume();
                    Console.WriteLine($"Mensaje recibido: {consumeResult.Message.Value}");
                }
            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"Error al consumir mensaje: {e.Error.Reason}");
            }
        }
    }
}
