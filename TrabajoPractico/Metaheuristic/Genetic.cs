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

        public Individual Start()
        {
            Best = PoblationGenerator.Original;

            while(!StopCriterion.IsEnd())
            {
                List<Individual> fathers = PoblationGenerator.Select();

                if(PoblationGenerator.Best.Evaluate() > Best.Evaluate() )
                {
                    Best = PoblationGenerator.Best;
                }

                List<Individual> childrens = MutationGenerator.Generate(fathers);

                if (GetBest(childrens).Evaluate() > Best.Evaluate())
                {
                    Best = GetBest(childrens);
                }

                var newPoblation = CrossOver.Cross(PoblationGenerator.Poblation, childrens);
                PoblationGenerator.Poblation = newPoblation;
                Individual bestNewPoblation = PoblationGenerator.GetBest();

                if (bestNewPoblation.Evaluate() > Best.Evaluate())
                {
                    Best = bestNewPoblation;
                }

                StopCriterion.Advance();
            }

            return Best;
        }

        private Individual GetBest(List<Individual> childrens)
        {
            List<Individual> selectedMatrices = childrens.OrderByDescending(x => x.Evaluate()).ToList();

            return selectedMatrices.FirstOrDefault();

        }
    }
}
