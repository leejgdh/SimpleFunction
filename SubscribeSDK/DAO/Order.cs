using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscribeSDK.DAO
{
    public class Order
    {
       
        public Order(string orderNo, string status)
        {
            OrderNo = orderNo;
            Status = status;
        }

        public string OrderNo { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public string Status { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

    }
}
