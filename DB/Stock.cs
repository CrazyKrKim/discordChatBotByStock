using LiteDB;

#nullable enable
namespace InvestSupTool.DB
{
    internal class Stock
    {
        [BsonId]
        public string StockCode { get; set; }

        public string StockName { get; set; }
    }
}
