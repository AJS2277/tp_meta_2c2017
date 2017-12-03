using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Interfaces
{
    public interface CrossOver
    {
        List<Individual> Cross(List<Individual> poblation, List<Individual> childrens);
        Individual Cross(Individual normal, Individual mutated);
    }
}
