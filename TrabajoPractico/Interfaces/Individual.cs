using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Interfaces
{
    public interface Individual
    {
        int Evaluate();
        void Mutate();
    }
}
