using System;
using System.Text;
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

            Console.WriteLine("Hello, World!");
            // Create Client instance
            MqttClient myClient = new MqttClient("127.0.0.1", 1883, false, null, null, MqttSslProtocols.None, null);

            // Register to message received
            myClient.MqttMsgPublishReceived += client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);

            // Subscribe to topic
            myClient.Subscribe(new string[] { "/testing" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            myClient.Publish("/testing", Encoding.ASCII.GetBytes(message));

            Console.ReadLine();
        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = Encoding.Default.GetString(e.Message);
            Console.WriteLine("Message received: " + message);
        }
    }
}
