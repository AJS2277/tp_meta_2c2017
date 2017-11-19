using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.Entities
{
    public class MatrizPoblationGenerator : PoblationGenerator
    {
        public MatrizPoblationGenerator(List<Individual> childrens) : base(childrens)
        {
        }

        public MatrizPoblationGenerator() : base()
        {
            
        }
    }
}
