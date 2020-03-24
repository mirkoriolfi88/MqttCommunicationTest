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
            string message = "123456|RICONTROLLO_SI";

            Console.WriteLine("Hello, World!");
            // Create Client instance
            MqttClient myClient = new MqttClient("192.168.0.98", 1883, false, null, null, MqttSslProtocols.None, null);

            // Register to message received
            myClient.MqttMsgPublishReceived += Client_recievedMessage;

            string clientId = "CASSA25_RETAILER055921";
            myClient.Connect(clientId);

            // Subscribe to topic
            myClient.Subscribe(new string[] { "/test/055921/25" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            myClient.Publish("/test/055921/25", Encoding.ASCII.GetBytes(message));

            Console.ReadLine();
        }

        static void Client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = Encoding.Default.GetString(e.Message);
            Console.WriteLine("Message received: " + message);
        }
    }
}
