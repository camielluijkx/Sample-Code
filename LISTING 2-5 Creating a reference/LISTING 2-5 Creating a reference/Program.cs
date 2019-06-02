using System;

namespace LISTING_2_5_Creating_a_reference
{
    class Alien
    {
        public int X;
        public int Y;
        public int Lives;

        public Alien()
        {

        }

        public Alien(int x, int y)
        {
            X = x;
            Y = y;
            Lives = 3;
        }

        public override string ToString()
        {
            return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Alien a = new Alien();
            a.X = 50;
            a.Y = 50;
            a.Lives = 3;
            Console.WriteLine("a {0}", a.ToString());

            Alien x = new Alien(100, 100);
            Console.WriteLine("x {0}", x);

            Alien[] swarm = new Alien[100];

            for (int i = 0; i < swarm.Length; i++)
                swarm[i] = new Alien(0, 0);

            Console.WriteLine("swarm [0] {0}", swarm[0]);
            //...
            Console.WriteLine("swarm [99] {0}", swarm[99]);

            Console.ReadKey();
        }
    }
}