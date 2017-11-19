using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.CrossOvers;
using TrabajoPractico.Entities;
using TrabajoPractico.Metaheuristic;
using TrabajoPractico.MutationGenerators;
using TrabajoPractico.StopCriterions;

namespace TrabajoPractico
{
    class Program
    {
        static void Main(string[] args)
        {
            var poblationGen = new MatrizPoblationGenerator();
            var stopCriterion = new LOStopCriterion1(10);
            var mutationGen = new MutationGenerator();
            var crossOver = new SimpleMatrizCrossOver();
            var genetic = new Genetic(poblationGen, stopCriterion, mutationGen, crossOver);

            var bestMatriz = (Matriz) genetic.Start();

            Console.WriteLine("Matriz: \n" + bestMatriz.ToString());
            Console.WriteLine(string.Format("Score: {0}\n", bestMatriz.Evaluate()));

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
