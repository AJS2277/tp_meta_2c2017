using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;
using TrabajoPractico.Utils.Object;

namespace TrabajoPractico.MutationGenerators
{
    public class MutationGenerator
    {
        public virtual List<Individual> Generate(List<Individual> fathers)
        {
            var mutations = new List<Individual>();

            foreach (Individual father in fathers)
            {
                var mutation = FactoryObject.DeepCopy(father);
                Mutate(mutation);

                mutations.Add(mutation);
            }

            return mutations;
        }

        public virtual void Mutate(Individual individual)
        {
        }
    }
}
