using System;

namespace ParallelLinqExample.Core.Processor
{
    public class StockPrice
    {
        public string ticker;
        public decimal price;
        public DateTime tradeDate;
        public double vol;
        public double change;
        public double changePercent;


        public StockPrice(string stockTicker, decimal stockPrice)
        {
           ticker = stockTicker;
           price = stockPrice;
        }
        
        public StockPrice(string stockTicker, DateTime date, decimal stockPrice, double volume, double change, double changePercent)
        {
            ticker = stockTicker;
            price = stockPrice;
            tradeDate = date;
            vol = volume;
            this.change = change;
            this.changePercent = changePercent;
        }
    };//
}