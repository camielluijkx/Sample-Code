﻿using System;

namespace LISTING_1_51_unsafe_thread_method
{
    class Counter
    {
        private int totalValue = 0;

        public void IncreaseCounter(int amount)
        {
            totalValue = totalValue + amount;
        }

        public int Total
        {
            get { return totalValue; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Counter count = new Counter();
            count.IncreaseCounter(25);

            Console.WriteLine($"Count value is: {count.Total}.");
            Console.ReadKey();

            /*
            
            Count value is: 25.

            */
        }
    }
}