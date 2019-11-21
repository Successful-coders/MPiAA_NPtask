using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NpTask
{
    public class Automobile
    {
        public int price = 0;
        public int weight = 0;
        public int koef = 0;
        public Automobile(int _weight, int _price)
        {
            price = _price;
            weight = _weight;
            koef = price / weight;
        }
    }
 

    public class Parom
    {
        public List<Automobile> subset = new List<Automobile>();//множество машин
        public List<Automobile> result = new List<Automobile>();
        private int maxWeight = 0;
        public int bestPrice = 0;
        public int numberOfAutomobile = 0;
        public Parom(int maxWeight_)
        {
            maxWeight = maxWeight_;
        }

        public void Create(string filename)
        {

            string writeLine = "";
            Random rnd = new Random();
            StreamWriter sw;
            FileInfo fi = new FileInfo(filename);
            sw = fi.CreateText();

            int number = rnd.Next(2, 15);
            numberOfAutomobile = number;
            sw.WriteLine(number.ToString());
            for (int i = 0; i < number; i++)
            {
                int weight = (rnd.Next(1, 10));
                int price = (rnd.Next(1, 100));

                writeLine = weight.ToString() + "-" + price.ToString();
                sw.WriteLine(writeLine);

                subset.Add(new Automobile(weight, price));
            }
            sw.Close();

        }


        public int SummW(List<Automobile> automobileSet)
        {
            int sumW = 0;
            if (automobileSet != null)
            {

                for (int i = 0; i < automobileSet.Count; i++)
                {

                    sumW += automobileSet[i].weight;
                }


            }
            return sumW;
        }

        public int SummP(List<Automobile> automobileSet)
        {
            int sumPrice = 0;
            if (automobileSet != null)
            {

                for (int i = 0; i < automobileSet.Count; i++)
                {

                    sumPrice += automobileSet[i].price;
                }


            }
            return sumPrice;
        }

        public void CheckSet(List<Automobile> automobileSet)
        {
            if (result == null)
            {
                if (SummW(automobileSet) <= maxWeight)
                {
                    result = automobileSet;
                    bestPrice = SummP(automobileSet);
                }
            }
            else
            {
                if (SummW(automobileSet) <= maxWeight && SummP(automobileSet) > bestPrice)
                {
                    result = automobileSet;
                    bestPrice = SummP(automobileSet);
                }
            }
        }
        public void EnumerationAutomobile (List<Automobile> automobileSet)
        {
            if (automobileSet != null)
            {
                if (automobileSet.Count > 0)
                    CheckSet(automobileSet);

                for (int i = 0; i < automobileSet.Count; i++)
                {
                    List<Automobile> newSet = new List<Automobile>(automobileSet);

                    newSet.RemoveAt(i);

                    EnumerationAutomobile(newSet);
                }
            }
        }

        private int CompareKoef(int x, int y)
        {
            if (x != y)
            {
                if (x > y)
                    return 1;
                if (x < y)
                    return -1;
            }
            return 0;
        }
        private void SortKoef ()
        {
            if (subset != null)
            {
                int temp;
                for (int i = 0; i < subset.Count - 1; i++)
                {
                    for (int j = i + 1; j < subset.Count; j++)
                    {
                        if (CompareKoef(subset[i].koef, subset[j].koef) == -1)
                        {
                            temp = subset[i].koef;
                            subset[i].koef = subset[j].koef;
                            subset[j].koef = temp;

                            temp = subset[i].price;
                            subset[i].price = subset[j].price;
                            subset[j].price = temp;

                            temp = subset[i].weight;
                            subset[i].weight = subset[j].weight;
                            subset[j].weight = temp;
                        }
                    }

                }
            }
        }

        public void GreedyAlgorithm()
        {
            if (subset != null)
            {
                SortKoef();
                if ((result.Count == 0) && (subset[0].weight <= maxWeight))
                {
                    result.Add(new Automobile(subset[0].weight, subset[0].price));
                    bestPrice += subset[0].price;
                }
                for (int i = 1; i < subset.Count; i++)
                {
                    List<Automobile> newSet = new List<Automobile>(result);
                    newSet.Add(new Automobile(subset[i].weight, subset[i].price));
                    if (SummW(newSet) <= maxWeight)
                    {
                        result.Add(new Automobile(subset[i].weight, subset[i].price));
                        bestPrice += subset[i].price;
                    }
                    newSet.Clear();
                }
            }
        }

    }
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int MAX =  rnd.Next(10, 120);
            Parom parom = new Parom(MAX);

            parom.Create("input.txt");
            Console.WriteLine(parom.numberOfAutomobile);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            parom.EnumerationAutomobile(parom.subset);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            parom.GreedyAlgorithm();
            stopwatch2.Stop();
            TimeSpan ts2 = stopwatch2.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts2.Hours, ts2.Minutes, ts2.Seconds,
                ts2.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime2);
        }
    }
}
