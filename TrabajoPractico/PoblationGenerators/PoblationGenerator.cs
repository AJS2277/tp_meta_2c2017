using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.PoblationGenerators
{
    public class PoblationGenerator
    {
        public Individual Original { get; set; }
        public List<Individual> Poblation { get; set; }
        public int Size { get; set; }

        public PoblationGenerator(Individual individual, int size)
        {
            Original = individual;
            Size = size;
            Generate();
        }

        public virtual void Generate()
        {

        }

        public List<Individual> Select()
        {
            return Poblation;
        }

        public Individual GetBest()
        {
            return Poblation.FirstOrDefault();
        }
    }
}
