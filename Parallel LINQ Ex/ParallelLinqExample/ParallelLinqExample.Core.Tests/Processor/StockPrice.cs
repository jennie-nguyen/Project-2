namespace ParallelLinqExample.Core.Processor
{
    public class StockPrice
    {
        public string ticker;
        public decimal price;

        public StockPrice(string stockTicker, decimal stockPrice)
        {
           ticker = stockTicker;
           price = stockPrice;
        }
    };//
}