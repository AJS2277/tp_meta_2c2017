using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Metaheuristic;

namespace TrabajoPractico
{
    class Program
    {
        static void Main(string[] args)
        {
            //var genetic = new Genetic();
            //genetic.Start();

        }

        private void TestScoreMethod()
        {
            var matrix = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 },
            };

            var matriz = new Matriz(matrix);

            Console.WriteLine("Matriz: \n" + matriz.ToString());
            Console.WriteLine(string.Format("Score: {0}\n", matriz.Evaluate()));

            matriz.Swap(0, 2);

            Console.WriteLine("Matriz: \n" + matriz.ToString());
            Console.WriteLine(string.Format("Score: {0}", matriz.Evaluate()));

            Console.ReadLine();
        }
             
    }
}
