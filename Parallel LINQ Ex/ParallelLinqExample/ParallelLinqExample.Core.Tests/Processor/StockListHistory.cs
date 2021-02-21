using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParallelLinqExample.Core.Processor
{
    public class StockListHistory : IEnumerable
    {
        private string v;
        private List<StockPrice> stockPrices;
        public List<StockPrice> StockPrices { get { return stockPrices; } }

        public StockListHistory(string csvFile)
        {
            stockPrices = new List<StockPrice>();
            //Load csvfile into dictionary
            using (TextFieldParser parser = new TextFieldParser(csvFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] indRecord = parser.ReadFields();
                    if (indRecord.Length == 6)
                    {
                        stockPrices.Add(new StockPrice
                            (
                                indRecord[0],
                                DateTime.Parse(indRecord[1]),
                                Convert.ToDecimal(indRecord[2]),
                                Convert.ToDouble(indRecord[3]),
                                Convert.ToDouble(indRecord[4]),
                                Convert.ToDouble(indRecord[5])
                               )
                            );
                    }
                    else
                    {
                        stockPrices.Add(new StockPrice(indRecord[0], Convert.ToDecimal(indRecord[1])));
                    }

                }
            }
        }

        public int getTickerStockPrices(string symbol)
        {
            IEnumerable<StockPrice> tickerPull =
                 from s in StockPrices
                 where s.ticker == symbol
                 select s;
            return tickerPull.Count();
        }

        public int getTickerStockPricesParallel(string symbol)
        {
            IEnumerable<StockPrice> tickerPull =
                 from s in StockPrices.AsParallel()
                 where s.ticker == symbol
                 select s;
            return tickerPull.Count();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

    }
}