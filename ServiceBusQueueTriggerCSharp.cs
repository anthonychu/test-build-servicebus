using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class ServiceBusQueueTriggerCSharp
    {
        [FunctionName("ServiceBusQueueTriggerCSharp")]
        public static Task Run(
            [ServiceBusTrigger("input", Connection = "ServiceBusConnection")]Thing myQueueItem, 
            [ServiceBus("test", Connection = "ServiceBusConnection")]IAsyncCollector<Thing> output,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var client = new HttpClient();
            var result = myQueueItem;

            return output.AddAsync(result);
        }
    }
}
