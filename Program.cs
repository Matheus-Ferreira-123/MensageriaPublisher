using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "fila1",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

string message = "Olá, mensagem de teste para o consumer!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(
    exchange: "",
    routingKey: "fila1",
    body: body);

Console.WriteLine($"Mensagem enviada: {message}");
