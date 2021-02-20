using System.Collections.Generic;

namespace ParallelLinqExample.Core.Processor
{
    public class StockPriceDictionary
    {
        private Dictionary<int, StockPrice> stockHistoryTable;
        public Dictionary<int, StockPrice> StockHistoryTable { get { return stockHistoryTable; } }

        public StockPriceDictionary(string csvFileName)
        {
            var file = csvFileName;
            //Load csvfile into dictionary
            stockHistoryTable = new Dictionary<int, StockPrice>()
            { {1,new StockPrice("AAP",230.3m) } };
        }
    }
}