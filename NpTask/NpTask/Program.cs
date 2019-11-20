using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NpTask
{
    class Automobile
    {
        public int price = 0;
        public int weight = 0;
        public Automobile(int _weight, int _price)
        {
            price = _price;
            weight = _weight;
        }
    }
 

    class Parom
    {
        public List<Automobile> subset = new List<Automobile>();//множество машин
        List<Automobile> result = null;
        private int maxWeight = 0;
        private int bestPrice = 0;

        public Parom(int maxWeight_)
        {
            maxWeight = maxWeight_;
        }

        public void Create(string filename)
        {

            string writeLine = "";
            Random rnd = new Random();
            StreamWriter sw;
            FileInfo fi = new FileInfo(filename); // информация о файле 
            sw = fi.CreateText(); // или поток для записи 

            int number = rnd.Next(2, 100);
            sw.WriteLine(number.ToString());
            for (int i = 0; i < number; i++)
            {
                int weight = (rnd.Next(1, 100));
                int price = (rnd.Next(1, 100));

                writeLine = weight.ToString() + "-" + price.ToString() ;
                sw.WriteLine(writeLine);

                subset.Add(new Automobile(weight, price));
            }
            sw.Close();

        }

        
        private int SummW(List<Automobile> automobileSet)
        {
            int sumW = 0;

            for (int i = 0; i < automobileSet.Count; i++)
            {

                sumW += automobileSet[i].weight;
            }
            

            return sumW;
        }

        private int SummP(List<Automobile> automobileSet)
        {
            int sumPrice = 0;

            for (int i = 0; i < automobileSet.Count; i++)
            {

                sumPrice += automobileSet[i].price;
            }


            return sumPrice;
        }

        private void CheckSet(List<Automobile> automobileSet)
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
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int MAX = rnd.Next(10, 20);
            Parom parom = new Parom(MAX);

            parom.Create("input.txt");

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
        }
    }
}
