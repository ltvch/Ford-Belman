using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belman_Ford_Algorithm
{
    class Program
    {
        private static int inf = 100000;
        private static int Vmax = 1000;
        private static int Emax = Vmax * (Vmax - 1) / 2;

        public struct Edges
        {
            public int u, v, w;
        }

        private static int e, start;
        public static Edges[] edge = new Edges[Emax];
        public static int[] d = new int[Vmax];


        public static void BelmanFord(int n, int s)
        {
            for (int i = 1; i < n; i++)
                d[s] = 0;

            for (int i = 1; i<n-1; i++)
                for (int j = 1; j<e-1; j++)
                    if (d[edge[j].v]+edge[j].w < d[edge[j].u])
                        d[edge[j].u] = d[edge[j].v] + edge[j].w;

            for (int i = 1; i < n; i++)
                if (d[i] == inf)
                    Console.WriteLine(start + "->" + i + "=", "Not");
                else
                    Console.WriteLine(start + "->" + i + "=", d[i]);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Count of vertex > ");
            int n = int.Parse(Console.ReadLine());
            e = 1;

            for(int i = 1; i < n; i++)
                for (int j = 1; j < n;j++)
                {
                    Console.WriteLine("Weight " + i + "->" + j + " > ");
                    int w = int.Parse(Console.ReadLine());

                    if (w != 0)
                    {
                        edge[e].v = i;
                        edge[e].u = j;
                        edge[e].w = w;
                        e++;
                    }
                }

            Console.WriteLine("Start vertex > ");
            start = int.Parse(Console.ReadLine());
            Console.WriteLine("List of short way: ");
            BelmanFord(n, start);
            Console.Read();
        }
    }
}
