using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;
using TrabajoPractico.MutationGenerators;
using TrabajoPractico.PoblationGenerators;

namespace TrabajoPractico.Metaheuristic
{
    public class Genetic
    {
        public PoblationGenerator PoblationGenerator { get; set; }
        public StopCriterion StopCriterion { get; set; }
        public MutationGenerator MutationGenerator { get; set; }
        public CrossOver CrossOver { get; set; }
        public Individual Best { get; set; }

        public Genetic(params object[] list)
        {
        }

        public Individual Start()
        {
            Best = PoblationGenerator.Original;

            while(!StopCriterion.IsEnd())
            {
                List<Individual> fathers = PoblationGenerator.Select();
                List<Individual> childrens = MutationGenerator.Generate(fathers);
                var newPoblation = CrossOver.Cross(PoblationGenerator.Poblation, childrens);
                PoblationGenerator.Poblation = newPoblation;
                StopCriterion.Advance();
            }

            Best = PoblationGenerator.GetBest();

            return Best;
        }
    }
}
