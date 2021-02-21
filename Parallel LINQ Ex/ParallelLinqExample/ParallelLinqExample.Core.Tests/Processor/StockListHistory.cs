using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;

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
                    stockPrices.Add(new StockPrice(indRecord[0], Convert.ToDecimal(indRecord[1])));
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}