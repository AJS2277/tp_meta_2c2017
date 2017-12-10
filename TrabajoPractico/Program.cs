using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.CrossOvers;
using TrabajoPractico.Entities;
using TrabajoPractico.Metaheuristic;
using TrabajoPractico.MutationGenerators;
using TrabajoPractico.PoblationGenerators;
using TrabajoPractico.StopCriterions;

namespace TrabajoPractico
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz matriz = GetSimpleMatriz();
            var poblationGen = new MatrizPoblationGeneratorRandom(matriz, 6, 3);
            var stopCriterion = new LOStopCriterion1(10);
            var mutationGen = new MutationGeneration1();
            var crossOver = new SimpleMatrizCrossOver();

            var genetic = new Genetic()
            {
                CrossOver = crossOver,
                StopCriterion = stopCriterion,
                MutationGenerator = mutationGen,
                PoblationGenerator = poblationGen
            };

            Console.WriteLine($"Matriz original: \n{matriz.ToString()}");
            Console.WriteLine($"Score original: {matriz.Fitness}\n\n");

            var bestMatriz = (Matriz) genetic.Start();

            Console.WriteLine($"Mejor matriz: \n{bestMatriz.ToString()}");
            Console.WriteLine($"Mejor score: {bestMatriz.Fitness}\n");
            Console.ReadLine();

        }

        private static Matriz GetSimpleMatriz()
        {
            var matrix = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 },
            };

            var matriz = new Matriz(matrix);

            return matriz;
        }
             
    }
}
