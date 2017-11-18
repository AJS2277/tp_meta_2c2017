using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.Metaheuristic
{
    public class Genetic
    {
        public Individual Start(PoblationGenerator poblationGen, StopCriterion stopCriterion, MutationGenerator mutationGen, CrossOver crossOver)
        {
            Individual bestIndividual;
            PoblationGenerator poblation = poblationGen;
            poblationGen.Generate();
            poblationGen.Evaluate();

            while(!stopCriterion.IsEnd())
            {
                List<Individual> fathers = poblation.Select();
                List<Individual> childrens = mutationGen.Generate(fathers);
                var childrensGen = new PoblationGenerator(childrens);
                childrensGen.Evaluate();
                var newPoblation = crossOver.Cross(fathers, childrens);
                poblation = new PoblationGenerator(newPoblation);
            }

            bestIndividual = poblation.GetBest();

            return bestIndividual;
        }
    }
}
