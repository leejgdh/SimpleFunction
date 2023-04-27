using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SubscribeSDK.DAO;

namespace SubscribeFunction
{
    public class OrderSubscribeFunction
    {
        private SubscribeContext _context;

        public OrderSubscribeFunction(
            SubscribeContext context
            )
        {
            _context = context;
        }

        [FunctionName("OrderInsert")]
        public async Task OrderInsertAsync([TimerTrigger("0/2 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var order = new Order(DateTime.Now.Ticks.ToString(), "READY_TO_SHIP")
            {
                OrderDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

        }
    }
}
