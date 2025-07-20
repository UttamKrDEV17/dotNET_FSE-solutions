using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Type your messages (Ctrl+C to exit):");
while (true)
{
    var value = Console.ReadLine();
    await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = value });
}
