using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("chat-topic");
Console.WriteLine("Listening for chat messages...");

while (true)
{
    var msg = consumer.Consume();
    Console.WriteLine($"Received: {msg.Value}");
}
