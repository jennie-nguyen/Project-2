using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParallelLinqExample.Core.Processor
{
    public class TickerPullProccessorTests
    {
        [Fact]
        public void ShouldReturnFirstKeyInStockPriceDictionary()
        {
            var myStockPriceDictionary = new StockPriceDictionary("StockPrices_xSmall.csv");


            //Act
            StockPrice result = myStockPriceDictionary.StockHistoryTable[1];

            //Assert
            Assert.NotNull(myStockPriceDictionary.StockHistoryTable);
            Assert.Equal("AAP",result.ticker);
            Assert.Equal(100.21m,result.price);
        }

        [Fact]
        public void ShouldReturnCountOfStockList()
        {
            var myStockListHistory = new StockListHistory("StockPrices_xSmall.csv");

            //Act
            int result = myStockListHistory.StockPrices.Count;

            //Assert
            Assert.NotNull(myStockListHistory);
            Assert.Equal(207, result);   
        }

        [Fact]
        public void ShouldReturnCountOfStockList2()
        {
            var myStockListHistory = new StockListHistory("StockPrices_Small.csv");

            //Act
            int result = myStockListHistory.StockPrices.Count;

            //Assert
            Assert.NotNull(myStockListHistory);
            Assert.Equal(95366, result);
        }

        [Fact]
        public void ShouldReturnCountOfTiker()
        {
            var myStockListHistory = new StockListHistory("StockPrices_Small.csv");

            //Act
            int result = myStockListHistory.getTickerStockPrices("TSLA");

            //Assert
            Assert.NotNull(myStockListHistory);
            Assert.Equal(41, result);
        }

        [Fact]
        public void ShouldReturnCountOfTikerParallel()
        {
            var myStockListHistory = new StockListHistory("StockPrices_Small.csv");

            //Act
            int result = myStockListHistory.getTickerStockPricesParallel("TSLA");

            //Assert
            Assert.NotNull(myStockListHistory);
            Assert.Equal(41, result);
        }
    }
}
