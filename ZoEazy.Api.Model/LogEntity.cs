using Microsoft.WindowsAzure.Storage.Table;

namespace ZoEazy.Api.Model
{
    public class LogEntity : TableEntity
    {
        public LogEntity(string subscriberId, string orderId)
        {
            PartitionKey = subscriberId;
            RowKey = orderId;
        }

        public LogEntity() { }

        public string CardNumber { get; set; }

        public decimal Total { get; set; }

        public string Message { get; set; }
    }
}