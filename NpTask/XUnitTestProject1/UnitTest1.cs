using System;
using NpTask;
using Xunit;
namespace XUnitTestProject1
{
    public class GredyAlgTest
    {
        [Fact]
        public void GreedyAlgorithm_Empty()
        {
            Parom parom = new Parom(20);
            parom.subset = null;
            parom.GreedyAlgorithm();
            Assert.Equal(null, parom.subset);
        }

        [Fact]
        public void GreedyAlgorithm_Alone()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(2, 18));
            parom.GreedyAlgorithm();
            Assert.Equal(parom.result[0].weight, parom.subset[0].weight);
            Assert.Equal(parom.result[0].price, parom.subset[0].price);
            Assert.Equal(parom.result[0].koef, parom.subset[0].koef);
        }

        [Fact]
        public void GreedyAlgorithm_FULL()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(2, 18));
            parom.subset.Add(new Automobile(10, 23));
            parom.subset.Add(new Automobile(4, 211));
            parom.subset.Add(new Automobile(4, 98));
            parom.subset.Add(new Automobile(5, 28));
            parom.GreedyAlgorithm();
            Assert.Equal(parom.bestPrice, 355);
        }

        [Fact]
        public void GreedyAlgorithm_Test()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(3, 67));
            parom.subset.Add(new Automobile(2, 94));
            parom.GreedyAlgorithm();
            Assert.Equal(parom.subset[0].weight, parom.result[0].weight);
            Assert.Equal(parom.subset[0].price, parom.result[0].price);
            Assert.Equal(parom.subset[1].weight, parom.result[1].weight);
            Assert.Equal(parom.subset[1].price, parom.result[1].price);
        }

        [Fact]
        public void GreedyAlgorithm_SortKoef()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(3, 67));
            parom.subset.Add(new Automobile(2, 94));
            parom.GreedyAlgorithm();
            Assert.Equal(parom.subset[0].weight, 2);
            Assert.Equal(parom.subset[0].price, 94);
            Assert.Equal(parom.subset[1].weight, 3);
            Assert.Equal(parom.subset[1].price, 67);
        }
    }

    public class EnumAlgoritm
    {
        [Fact]
        public void EnumAuto_Empty()
        {

            Parom parom = new Parom(20);
            parom.subset = null;
            parom.EnumerationAutomobile(parom.subset);
            Assert.Equal(null , parom.subset);
        }

        [Fact]
        public void EnumAuto_FULL()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(2, 18));
            parom.subset.Add(new Automobile(10, 23));
            parom.subset.Add(new Automobile(4, 211));
            parom.subset.Add(new Automobile(4, 98));
            parom.subset.Add(new Automobile(5, 28));
            parom.GreedyAlgorithm();
            Assert.Equal(parom.bestPrice, 355);
        }

        [Fact]
        public void EnumAuto_Alone()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(2, 18));
            parom.EnumerationAutomobile(parom.subset);
            Assert.Equal(parom.result[0].weight, parom.subset[0].weight);
            Assert.Equal(parom.result[0].price, parom.subset[0].price);
            Assert.Equal(parom.result[0].koef, parom.subset[0].koef);
        }

        [Fact]
        public void EnumAuto_Test()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(3, 67));
            parom.subset.Add(new Automobile(2, 94));
            parom.EnumerationAutomobile(parom.subset);
            Assert.Equal(parom.subset[0].weight, parom.result[0].weight);
            Assert.Equal(parom.subset[0].price, parom.result[0].price);
            Assert.Equal(parom.subset[1].weight, parom.result[1].weight);
            Assert.Equal(parom.subset[1].price, parom.result[1].price);
        }

        [Fact]
        public void CheckSet_Test()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(3, 67));
            parom.subset.Add(new Automobile(2, 94));
            parom.CheckSet(parom.subset);
            Assert.Equal(parom.subset[0].weight, parom.result[0].weight);
            Assert.Equal(parom.subset[0].price, parom.result[0].price);
            Assert.Equal(parom.subset[1].weight, parom.result[1].weight);
            Assert.Equal(parom.subset[1].price, parom.result[1].price);
        }

        [Fact]
        public void Summ_Test()
        {
            Parom parom = new Parom(20);
            parom.subset.Add(new Automobile(3, 67));
            parom.subset.Add(new Automobile(2, 94));
            Assert.Equal(parom.SummW(parom.subset), 5);
            Assert.Equal(parom.SummP(parom.subset), 161);
        }

        [Fact]
        public void Summ_TestEmpty()
        {
            Parom parom = new Parom(20);
            parom.subset = null;
            Assert.Equal(parom.SummW(parom.subset), 0);
            Assert.Equal(parom.SummP(parom.subset), 0);
        }
    }

}
