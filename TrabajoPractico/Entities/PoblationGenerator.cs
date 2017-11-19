using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.Entities
{
    public class PoblationGenerator
    {
        private List<Individual> childrens;

        public PoblationGenerator(List<Individual> childrens)
        {
            this.childrens = childrens;
        }

        public PoblationGenerator()
        {

        }

        public List<Individual> Poblation { get; set; }

        public void Evaluate()
        {
            foreach(var individual in Poblation)
            {
                individual.Evaluate();
            }
        }

        public virtual void Generate()
        {
            var poblation = new List<Individual>();
            Poblation = poblation;
        }

        public List<Individual> Select()
        {
            throw new NotImplementedException();
        }

        internal Individual GetBest()
        {
            throw new NotImplementedException();
        }
    }
}
