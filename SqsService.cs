using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AwsSqsXml
{
    public class SqsService
    {
        private readonly AmazonSQSClient _sqsClient;
        private const string QueueUrl = "https://sqs.eu-north-1.amazonaws.com/888577025424/Ismail";  

        public SqsService()
        {
            _sqsClient = new AmazonSQSClient(Amazon.RegionEndpoint.EUNorth1);
        }

        public async Task<List<MessageData>> ReceiveMessagesAsync()
        {
            var messages = new List<MessageData>();
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = QueueUrl,
                MaxNumberOfMessages = 2,  
                WaitTimeSeconds = 20      
            };

            var response = await _sqsClient.ReceiveMessageAsync(receiveMessageRequest);

            foreach (var message in response.Messages)
            {
                try
                {
                    var jsonString = DecodeAsciiToJson(message.Body);

                    var data = System.Text.Json.JsonSerializer.Deserialize<MessageData>(message.Body);
                    messages.Add(data);

                    await _sqsClient.DeleteMessageAsync(new DeleteMessageRequest
                    {
                        QueueUrl = QueueUrl,
                        ReceiptHandle = message.ReceiptHandle
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                }
            }

            return messages;
        }
        private string DecodeAsciiToJson(string asciiData)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(asciiData);
            return Encoding.ASCII.GetString(asciiBytes);
        }
    }

    public class MessageData
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }

        public string  clubName { get; set; }
        public string uuid { get; set; }
        public string clubLogo { get; set; }
    }
}
