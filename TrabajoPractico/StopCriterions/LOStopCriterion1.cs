using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.StopCriterions
{
    public class LOStopCriterion1 : StopCriterion
    {
        public int TotalIterations { get; set; }
        public int Iterations { get; set; } = 0;

        public LOStopCriterion1(int iterations)
        {
            TotalIterations = iterations;
        }

        public bool IsEnd()
        {
            return Iterations == TotalIterations;
        }

        public void Advance()
        {
            Iterations++;
        }
    }
}
