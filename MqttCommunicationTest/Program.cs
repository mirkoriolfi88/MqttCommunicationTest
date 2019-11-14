using System;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttCommunicationTest
{
    class Program
    {
        const string topic = "test/test/button";

        static void Main(string[] args)
        {
            string message = "Test Message";

            //Task.Run(() => 
            //{
            //    try
            //    {
            //        var config = new MqttConfiguration { Port = 1883 };
            //        var client = MqttClient.CreateAsync("test.mosquitto.org", config).Result;
            //        var clientId = "myClientID";

            //        client.ConnectAsync(new MqttClientCredentials(clientId)).Wait();
            //        client.SubscribeAsync(topic, MqttQualityOfService.AtLeastOnce).Wait();
            //        //Publishes "message" Var 
            //        client.PublishAsync(new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(message)), MqttQualityOfService.AtLeastOnce).Wait();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message.ToString());
            //    }
            //});

            Console.WriteLine("Hello, World!");
            // Create Client instance
            uPLibrary.Networking.M2Mqtt.MqttClient myClient = new uPLibrary.Networking.M2Mqtt.MqttClient("test.mosquitto.org", 1883, false, null, null, MqttSslProtocols.None, null);

            // Register to message received
            myClient.MqttMsgPublishReceived += client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);

            // Subscribe to topic
            myClient.Subscribe(new string[] { "/testing" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            Console.ReadLine();
        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = Encoding.Default.GetString(e.Message);
            Console.WriteLine("Message received: " + message);
        }

        public async Task MqttConnectionTest(string message)
        {
            //...
            //try
            //{
            //    var config = new MqttConfiguration { Port = 1883 };
            //    var client = MqttClient.CreateAsync("test.mosquitto.org", config).Result;
            //    var clientId = "myClientID";

            //    client.ConnectAsync(new MqttClientCredentials(clientId)).Wait();
            //    client.SubscribeAsync(topic, MqttQualityOfService.AtLeastOnce).Wait();
            //    //Publishes "message" Var 
            //    client.PublishAsync(new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(message)), MqttQualityOfService.AtLeastOnce).Wait();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message.ToString());
            //}
        }
    }
}
