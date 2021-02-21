using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace ParallelLinqExample.Core.Processor
{
    public class StockPriceDictionary
    {
        private Dictionary<int, StockPrice> stockHistoryTable;
        public Dictionary<int, StockPrice> StockHistoryTable { get { return stockHistoryTable; } }

        public StockPriceDictionary(string csvFileName)
        {
            //Load csvfile into dictionary
            stockHistoryTable = new Dictionary<int, StockPrice>();
            using (TextFieldParser parser = new TextFieldParser(csvFileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int i = 1;
                while (!parser.EndOfData)
                {
                    string[] indRecord = parser.ReadFields();
                    stockHistoryTable.Add(i, new StockPrice(indRecord[0], Convert.ToDecimal(indRecord[1])));
                    Console.WriteLine("Key = {0}, Value = {1}", i, stockHistoryTable[i]);
                    i++;
                }
            }
        }
    }
}
