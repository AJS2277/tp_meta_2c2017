using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.CrossOvers;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;
using TrabajoPractico.MutationGenerators;
using TrabajoPractico.PoblationGenerators;
using TrabajoPractico.StopCriterions;

namespace TrabajoPractico.Metaheuristic
{
    public class LOGenetic : Genetic
    {
        public LOGenetic(Matriz matrix, int poblationSize, int selectionCount, int iterNumber)
        {
            var poblationGen = new MatrizPoblationGeneratorRandom(matrix, poblationSize, selectionCount);
            var stopCriterion = new LOStopCriterion1(iterNumber);
            var mutationGen = new MutationGeneration1();
            var crossOver = new SimpleMatrizCrossOver();

            CrossOver = crossOver;
            StopCriterion = stopCriterion;
            MutationGenerator = mutationGen;
            PoblationGenerator = poblationGen;
        }
    }
}
