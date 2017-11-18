using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Interfaces
{
    public interface CrossOver
    {
        List<Individual> Cross(List<Individual> fathers, List<Individual> childrens);
    }
}
