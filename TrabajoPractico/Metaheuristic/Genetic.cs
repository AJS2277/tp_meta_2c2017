using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;
using TrabajoPractico.MutationGenerators;

namespace TrabajoPractico.Metaheuristic
{
    public class Genetic
    {
        public PoblationGenerator PoblationGenerator { get; set; }
        public StopCriterion StopCriterion { get; set; }
        public MutationGenerator MutationGenerator { get; set; }
        public CrossOver CrossOver { get; set; }

        public Genetic(PoblationGenerator poblationGen, StopCriterion stopCriterion, MutationGenerator mutationGen, CrossOver crossOver)
        {
            PoblationGenerator = poblationGen;
            StopCriterion = stopCriterion;
            MutationGenerator = mutationGen;
            CrossOver = crossOver;
        }

        public Individual Start()
        {
            Individual bestIndividual;
            PoblationGenerator poblation = PoblationGenerator;
            PoblationGenerator.Generate();
            PoblationGenerator.Evaluate();

            while(!StopCriterion.IsEnd())
            {
                List<Individual> fathers = poblation.Select();
                List<Individual> childrens = MutationGenerator.Generate(fathers);
                var childrensGen = new PoblationGenerator(childrens);
                childrensGen.Evaluate();
                var newPoblation = CrossOver.Cross(poblation.Poblation, childrens);
                poblation = new PoblationGenerator(newPoblation);
                StopCriterion.Advance();
            }

            bestIndividual = poblation.GetBest();

            return bestIndividual;
        }
    }
}
