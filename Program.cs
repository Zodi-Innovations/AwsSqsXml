using AwsSqsXml;

class Program
{
    static async Task Main(string[] args)
    {
        var labelService = new LabelService();
        var sqsService = new SqsService();

        string xmlContent = @"C:\Users\ismai\Downloads\demo.dymo";  

        while (true)
        {
            var messages = await sqsService.ReceiveMessagesAsync();

            foreach (var message in messages)
            {
                labelService.UpdateLabelXml(xmlContent, message);

                Console.WriteLine("Wijziging is doorgevoerd op het label.");
            }

            await Task.Delay(5000);
        }
    }
}
