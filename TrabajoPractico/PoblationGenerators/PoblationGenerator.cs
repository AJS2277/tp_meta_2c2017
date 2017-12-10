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
        public int Selections { get; set; }
        public int Size { get; set; }
        public Individual Best { get; set; }

        public PoblationGenerator(Individual individual, int size, int selections)
        {
            Original = individual;
            Size = size;

            if(selections > size)
            {
                throw new Exception("La selección no puede ser mejor al tamaño de la población");
            }

            Selections = selections;
            Generate();
        }

        public virtual void Generate()
        {

        }

        public virtual List<Individual> Select()
        {
            return Poblation;
        }

        public virtual Individual GetBest()
        {
            return Poblation.FirstOrDefault();
        }
    }
}
